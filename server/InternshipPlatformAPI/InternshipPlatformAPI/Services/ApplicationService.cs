using AutoMapper;
using InternshipPlatformAPI.Data;
using InternshipPlatformAPI.Dtos;
using InternshipPlatformAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient.Server;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace InternshipPlatformAPI.Services
{
    public class ApplicationService : IApplicationService
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public ApplicationService(DataContext dataContext, IMapper mapper)
        {
            this._dataContext = dataContext;
            this._mapper = mapper;
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

        public async Task<ServiceResponse<List<ApplicationDto>>> GetApplications(int page , int pageSize, string sortBy,string filter)
        {
            var serviceResponse = new ServiceResponse<List<ApplicationDto>>();
            var pagesCount = await this._dataContext.Applications.CountAsync() / pageSize;
            serviceResponse.PagesCount = pagesCount  == 0 ? 1 : pagesCount ;

            IQueryable<Application> applications;
            switch (sortBy)
            {
                case "name":
                    applications = this._dataContext.Applications.OrderBy(x => x.FirstName).Where(x =>
                   x.FirstName.ToLower().Contains(filter.ToLower())).Skip((page - 1) * pageSize).Take(pageSize);
                    break;
                case "EducationLevel":
                    applications = this._dataContext.Applications.OrderBy(x => x.EducationLevel).Where(x=>x.EducationLevel.ToLower().Contains(filter.ToLower())).Skip((page - 1) * pageSize).Take(pageSize);
                    break;
                case "Status":
                    applications = this._dataContext.Applications.OrderBy(x => x.Status).Where(x=>x.Status.ToLower().Contains(filter.ToLower())).Skip((page - 1) * pageSize).Take(pageSize);
                    break;
                 default:
                    applications = this._dataContext.Applications.OrderBy(x => x.Id).Skip((page - 1) * pageSize).Take(pageSize);
                    break;
            }
            var results = await applications.ToListAsync();
            serviceResponse.Data = results.Select(c=>this._mapper.Map<ApplicationDto>(c)).ToList();
            return serviceResponse;
        }
    }
}
