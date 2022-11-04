using AutoMapper;
using InternshipPlatformAPI.Data;
using InternshipPlatformAPI.Dtos;
using InternshipPlatformAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InternshipPlatformAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationFormController : ControllerBase
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public ApplicationFormController(DataContext dataContext,IMapper mapper)
        {
            this._dataContext = dataContext ?? throw new ArgumentNullException(nameof(dataContext));
            this._mapper = mapper ?? throw new ArgumentNullException(nameof(dataContext));
            ;
        }
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<ApplicationFormDto>>> PostApplication(ApplicationFormDto formData)
        {
            var insertData = this._mapper.Map<Application>(formData);
            this._dataContext.Applications.Add(insertData);
            await this._dataContext.SaveChangesAsync();
            var serviceResponse = new ServiceResponse<ApplicationFormDto>();
            serviceResponse.Data = formData;
            return Ok(serviceResponse);
        }
    }
}
