using AutoMapper;
using InternshipPlatformAPI.Data;
using InternshipPlatformAPI.Dtos.ApplicationDto;
using InternshipPlatformAPI.Models;
using InternshipPlatformAPI.Services.EmailService;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MimeKit;
using Newtonsoft.Json;
using SendGrid;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace InternshipPlatformAPI.Services
{
    public class ApplicationService : IApplicationService
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IEmailService _emailService;
        private readonly ISendGridClient sendGridClient;

        public ApplicationService(DataContext dataContext, IMapper mapper,IHttpContextAccessor httpContextAccessor,IEmailService emailService,ISendGridClient sendGridClient)
        {
            this._dataContext = dataContext;
            this._mapper = mapper;
            this._httpContextAccessor = httpContextAccessor;
            this._emailService = emailService;
            this.sendGridClient = sendGridClient;
        }

        

        public async Task<ServiceResponse<ApplicationFormDto>> PostApplication(ApplicationFormDto applicationFormDto)
        {
            var serviceResponse = new ServiceResponse<ApplicationFormDto>();
           
            try
            {
            var insertData = this._mapper.Map<Application>(applicationFormDto);
            this._dataContext.Applications.Add(insertData);
            await this._dataContext.SaveChangesAsync();
            serviceResponse.Data = applicationFormDto;
            }catch(Exception ex) {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<ApplicationDto>>> GetApplications(int page , int pageSize, string sortBy,string filter,string filterType)
        {
            var serviceResponse = new ServiceResponse<List<ApplicationDto>>();
            IQueryable<Application> applications;
            var count = await _dataContext.Applications.CountAsync();
            switch (filterType)
            {
                case "name":
                    applications = this._dataContext.Applications.Where(x => x.FirstName.ToLower().Contains(filter.ToLower()));
                    break;
                case "EducationLevel":
                    applications = this._dataContext.Applications.Where(x => x.EducationLevel.ToLower().Contains(filter.ToLower()));
                    break;
                case "Status":
                    applications = this._dataContext.Applications.Where(x => x.Status.ToLower().Contains(filter.ToLower()));
                    break;
                default:
                    applications = this._dataContext.Applications;
                    break;
            }
            serviceResponse.PagesCount = (await applications.CountAsync() / pageSize) + 1;
            switch (sortBy)
            {
                case "name_asc":
                    applications = applications.OrderBy(x => x.FirstName).Skip((page - 1) * pageSize).Take(pageSize);
                    break;
                case "name_desc":
                    applications = applications.OrderByDescending(x => x.FirstName).Skip((page - 1) * pageSize).Take(pageSize);
                    break;
                case "EducationLevel_asc":
                    applications = applications.OrderBy(x => x.EducationLevel).Skip((page - 1) * pageSize).Take(pageSize);
                    break;
                case "EducationLevel_desc":
                    applications = applications.OrderByDescending(x => x.EducationLevel).Skip((page - 1) * pageSize).Take(pageSize);
                    break;
                case "Status_asc":
                    applications = applications.OrderBy(x => x.Status).Skip((page - 1) * pageSize).Take(pageSize);
                    break;
                case "Status_desc":
                    applications = applications.OrderByDescending(x => x.Status).Skip((page - 1) * pageSize).Take(pageSize);
                    break;
                default:
                    applications = applications.OrderBy(x => x.Id).Skip((page - 1) * pageSize).Take(pageSize);
                    break;
            }
           
            var results = await applications.ToListAsync();
           
            serviceResponse.Data = results.Select(c=>this._mapper.Map<ApplicationDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<Application>> GetSingleApplication(Guid id)
        {
            var serviceResponse = new ServiceResponse<Application>();
            var user = await this._dataContext.Applications.FirstOrDefaultAsync(a=>a.Id==id);
                //FirstOrDefaultAsync(b => b.Id == id);
                //.FirstOrDefaultAsync(x => x.Id == id);
            
            if (user == null)
            {

                serviceResponse.Success = false;
                serviceResponse.Message = "Applicant not found!";
            }
            else
            {
                serviceResponse.Data = user;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<Application>> UpdateApplication(Guid id, ApplicationUpdateDto updateDto)
        {
            var serviceResponse = new ServiceResponse<Application>();
            var application = await this._dataContext.Applications.FirstOrDefaultAsync(x => x.Id == id);
            if (application == null)
            {

                serviceResponse.Success = false;
                serviceResponse.Message = "Applicant not found!";
            }
            else
            {
                if(updateDto.Status.ToLower() == "in-selection")
                {
                    await this._emailService.SendEmailAsync(application.Email, "Internship update", "Welcome to Internship!");
                    
                }
                application.Status = updateDto.Status;
                await this._dataContext.SaveChangesAsync();
                serviceResponse.Data = application;
            }
            return serviceResponse;
            //throw new NotImplementedException();
        }

        public async Task<ServiceResponse<Comment>> AddApplicationComment(ApplicationCommentDto commentData,Guid id)
        {
            var serviceResponse = new ServiceResponse<Comment>();
            var application = await this._dataContext.Applications.FirstOrDefaultAsync(x => x.Id == id);
            var loggedUserId = this._httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var user = await this._dataContext.Users.FirstOrDefaultAsync(x => x.Id == loggedUserId);

            //var user2 = await this._dataContext.AspNetUsers.
            if (application == null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Application not found.";
                return serviceResponse;
            }
             if(user == null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "User not found.";
                return serviceResponse;
            }
            var comment = new Comment() { CommentText = commentData.CommentText };
            var addComment = _mapper.Map<Comment>(comment);
            addComment.DateCreated = DateTime.Now;
             this._dataContext.Comments.Add(addComment);
            var applicationComment = new ApplicationComment()
            {
                Comment = addComment,
                Application = application,
                User = user
            };
            this._dataContext.ApplicationComments.Add(applicationComment);
            serviceResponse.Data = addComment;
            await this._dataContext.SaveChangesAsync();
            //serviceResponse.Data = results.Select(c=>this._mapper.Map<ApplicationDto>(c)).ToList();
            return serviceResponse;

        }
        private void SendEmail(string sendTo,string textToSend)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("moses.rosenbaum@ethereal.email"));
            email.To.Add(MailboxAddress.Parse(sendTo));
            email.Subject = "Test Email Subject";
            email.Body = new TextPart(MimeKit.Text.TextFormat.Text) { Text = textToSend };
            using var smtp = new SmtpClient();
            smtp.Connect("smtp.ethereal.email",587,SecureSocketOptions.StartTls);
            smtp.Authenticate("moses.rosenbaum@ethereal.email", "k6G8zkkujSpnVjkZBY");
            smtp.Send(email);
            smtp.Disconnect(true);
        }

        //public async Task<ServiceResponse<Application>> GetSingleApplication(Guid id)
        //{
        //    var serviceResponse = new ServiceResponse<Application>();
        //    var user = await this._dataContext.Applications.FirstOrDefaultAsync(a=>a.Id==id);
        //        //FirstOrDefaultAsync(b => b.Id == id);
        //        //.FirstOrDefaultAsync(x => x.Id == id);
            
        //    if (user == null)
        //    {

        //        serviceResponse.Success = false;
        //        serviceResponse.Message = "Applicant not found!";
        //    }
        //    else
        //    {
        //        serviceResponse.Data = user;
        //    }
        //    return serviceResponse;
        //}

        //public async Task<ServiceResponse<Application>> UpdateApplication(Guid id, ApplicationUpdateDto updateDto)
        //{
        //    var serviceResponse = new ServiceResponse<Application>();
        //    var application = await this._dataContext.Applications.FirstOrDefaultAsync(x => x.Id == id);
        //    if (application == null)
        //    {

        //        serviceResponse.Success = false;
        //        serviceResponse.Message = "Applicant not found!";
        //    }
        //    else
        //    {
        //        application.Status = updateDto.Status;
        //        await this._dataContext.SaveChangesAsync();
        //        serviceResponse.Data = application;
        //    }
        //    return serviceResponse;
        //    //throw new NotImplementedException();
        //}

        //public async Task<ServiceResponse<Comment>> AddApplicationComment(ApplicationCommentDto commentData)
        //{
        //    var serviceResponse = new ServiceResponse<Comment>();
        //    var application = await this._dataContext.Applications.FirstOrDefaultAsync(x => x.Id == commentData.Id);
        //    var user = await this._dataContext.Users.FirstOrDefaultAsync(x => x.Id == commentData.userId);
        //    //var user2 = await this._dataContext.AspNetUsers.
        //    if(application == null)
        //    {
        //        serviceResponse.Success = false;
        //        serviceResponse.Message = "Application not found.";
        //        return serviceResponse;
        //    }
        //     if(user == null)
        //    {
        //        serviceResponse.Success = false;
        //        serviceResponse.Message = "User not found.";
        //        return serviceResponse;
        //    }
        //    var comment = new Comment() { CommentText = commentData.CommentText };
        //    var addComment = _mapper.Map<Comment>(comment);
        //    addComment.DateCreated = DateTime.Now;
        //     this._dataContext.Comments.Add(addComment);
        //    var applicationComment = new ApplicationComment()
        //    {
        //        Comment = addComment,
        //        Application = application,
        //        User = user
        //    };
        //    this._dataContext.ApplicationComments.Add(applicationComment);
        //    serviceResponse.Data = addComment;
        //    await this._dataContext.SaveChangesAsync();
        //    //serviceResponse.PagesCount = (results.Count() /pageSize)+1;
        //    //serviceResponse.Data = results.Select(c=>this._mapper.Map<ApplicationDto>(c)).ToList();
        //    return serviceResponse;
        //}
    }
}
