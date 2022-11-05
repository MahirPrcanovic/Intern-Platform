using AutoMapper;
using InternshipPlatformAPI.Data;
using InternshipPlatformAPI.Dtos;
using InternshipPlatformAPI.Models;
using Microsoft.Data.SqlClient.Server;

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
    }
}
