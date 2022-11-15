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

namespace InternshipPlatformAPI.Services.ApplicationService
{
    public class ApplicationService : IApplicationService
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IEmailService _emailService;
        private readonly ISendGridClient sendGridClient;

        public ApplicationService(DataContext dataContext, IMapper mapper, IHttpContextAccessor httpContextAccessor, IEmailService emailService, ISendGridClient sendGridClient)
        {
            _dataContext = dataContext;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _emailService = emailService;
            this.sendGridClient = sendGridClient;
        }

        public async Task<ServiceResponse<ApplicationFormDto>> Post(ApplicationFormDto applicationFormDto)
        {
            var serviceResponse = new ServiceResponse<ApplicationFormDto>();
            try
            {
                var insertData = _mapper.Map<Application>(applicationFormDto);
                _dataContext.Applications.Add(insertData);
                await _dataContext.SaveChangesAsync();
                serviceResponse.Data = applicationFormDto;
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<ApplicationDto>>> Get(int page, int pageSize, string sortBy, string filter, string filterType)
        {
            var serviceResponse = new ServiceResponse<List<ApplicationDto>>();
            IQueryable<Application> applications;
            var count = await _dataContext.Applications.CountAsync();
            switch (filterType)
            {
                case "name":
                    applications = _dataContext.Applications.Where(x => x.FirstName.Trim().ToLower().Contains(filter.Trim().ToLower()));
                    break;
                case "EducationLevel":
                    applications = _dataContext.Applications.Where(x => x.EducationLevel.Trim().ToLower().Contains(filter.Trim().ToLower()));
                    break;
                case "Status":
                    applications = _dataContext.Applications.Where(x => x.Status.Trim().ToLower().Contains(filter.Trim().ToLower()));
                    break;
                default:
                    applications = _dataContext.Applications;
                    break;
            }
            serviceResponse.PagesCount = await applications.CountAsync() / pageSize + 1;
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
            serviceResponse.Data = results.Select(c => _mapper.Map<ApplicationDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<Application>> Get(Guid id)
        {
            var serviceResponse = new ServiceResponse<Application>();
            var user = await _dataContext.Applications.FirstOrDefaultAsync(a => a.Id == id);
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

        public async Task<ServiceResponse<Application>> Update(Guid id, ApplicationUpdateDto updateDto)
        {
            var serviceResponse = new ServiceResponse<Application>();
            var application = await _dataContext.Applications.FirstOrDefaultAsync(x => x.Id == id);
            if (application == null)
            {

                serviceResponse.Success = false;
                serviceResponse.Message = "Applicant not found!";
            }
            else
            {
                if (updateDto.Status.ToLower() == "in-selection")
                {
                    await _emailService.SendEmailAsync(application.Email, "Internship update", "Welcome to Internship!");

                }
                application.Status = updateDto.Status;
                await _dataContext.SaveChangesAsync();
                serviceResponse.Data = application;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<Comment>> PostComment(ApplicationCommentDto commentData, Guid id)
        {
            var serviceResponse = new ServiceResponse<Comment>();
            var application = await _dataContext.Applications.FirstOrDefaultAsync(x => x.Id == id);
            var loggedUserId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var user = await _dataContext.Users.FirstOrDefaultAsync(x => x.Id == loggedUserId);
            if (application == null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "Application not found.";
                return serviceResponse;
            }
            if (user == null)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = "User not found.";
                return serviceResponse;
            }
            var comment = new Comment() { CommentText = commentData.CommentText };
            var addComment = _mapper.Map<Comment>(comment);
            addComment.DateCreated = DateTime.Now;
            _dataContext.Comments.Add(addComment);
            var applicationComment = new ApplicationComment()
            {
                Comment = addComment,
                Application = application,
                User = user
            };
            _dataContext.ApplicationComments.Add(applicationComment);
            serviceResponse.Data = addComment;
            await _dataContext.SaveChangesAsync();
            return serviceResponse;
        }
    }
}
