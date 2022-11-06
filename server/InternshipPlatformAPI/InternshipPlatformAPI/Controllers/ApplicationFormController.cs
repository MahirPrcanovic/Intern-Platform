using AutoMapper;
using InternshipPlatformAPI.Data;
using InternshipPlatformAPI.Dtos;
using InternshipPlatformAPI.Models;
using InternshipPlatformAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InternshipPlatformAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationFormController : ControllerBase
    {
        private readonly IApplicationService _applicationService;

        public ApplicationFormController(IApplicationService applicationService)
        {
            this._applicationService = applicationService;
        }
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Application>>>> GetApplications(int? page=1, int? pageSize=10, string? sortBy="name",string? filter="")
        {
            
            return Ok(await this._applicationService.GetApplications((int)page, (int)pageSize, sortBy, filter));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<ApplicationFormDto>>> PostApplication(ApplicationFormDto formData)
        {

            var serviceR = await this._applicationService.PostApplication(formData);
            if (serviceR.Success)
            {
                return Ok(serviceR);
            }
            return BadRequest(serviceR);
        }
    }
}
