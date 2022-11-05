using AutoMapper;
using InternshipPlatformAPI.Data;
using InternshipPlatformAPI.Dtos;
using InternshipPlatformAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient.Server;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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

        public async Task<ServiceResponse<List<Application>>> GetApplications(int page , int pageSize, string sortBy, string filterName,string filterValue)
        {
            var serviceResponse = new ServiceResponse<List<Application>>();
            IQueryable<Application> applications;
            switch (sortBy)
            {
                case "name":
                    applications = this._dataContext.Applications.OrderBy(x => x.FirstName).Skip((page - 1) * pageSize).Take(pageSize);
                    break;
                case "EducationLevel":
                    applications = this._dataContext.Applications.OrderBy(x => x.EducationLevel).Skip((page - 1) * pageSize).Take(pageSize);
                    break;
                case "Status":
                    applications = this._dataContext.Applications.OrderBy(x => x.Status).Skip((page - 1) * pageSize).Take(pageSize);
                    break;
                 default:
                    applications = this._dataContext.Applications.OrderBy(x => x.Id).Skip((page - 1) * pageSize).Take(pageSize);
                    break;
            }
            var results = await applications.ToListAsync();
            serviceResponse.Data = results;
            return serviceResponse;
        }
    }
}
