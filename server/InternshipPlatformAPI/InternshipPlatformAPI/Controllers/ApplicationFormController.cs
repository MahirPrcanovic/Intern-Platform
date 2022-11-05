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
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<ApplicationFormDto>>> PostApplication(ApplicationFormDto formData)
        {
            
            return Ok(await this._applicationService.PostApplication(formData));
        }
    }
}
