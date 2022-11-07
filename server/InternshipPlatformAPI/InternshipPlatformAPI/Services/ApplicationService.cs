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
            switch (sortBy)
            {
                case "name":
                    applications = applications.OrderBy(x => x.FirstName).Skip((page - 1) * pageSize).Take(pageSize);
                    break;
                case "EducationLevel":
                    applications = applications.OrderBy(x => x.EducationLevel).Skip((page - 1) * pageSize).Take(pageSize);
                    break;
                case "Status":
                    applications = applications.OrderBy(x => x.Status).Skip((page - 1) * pageSize).Take(pageSize);
                    break;
                 default:
                    applications = applications.OrderBy(x => x.Id).Skip((page - 1) * pageSize).Take(pageSize);
                    break;
            }
      
            var results = await applications.ToListAsync();
            serviceResponse.PagesCount = (results.Count() /pageSize)+1;
            serviceResponse.Data = results.Select(c=>this._mapper.Map<ApplicationDto>(c)).ToList();
            return serviceResponse;
        }
    }
}
