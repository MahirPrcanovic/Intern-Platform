using InternshipPlatformAPI.Dtos;
using InternshipPlatformAPI.Models;
using InternshipPlatformAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InternshipPlatformAPI.Controllers
{
    //[Authorize(Roles = "Administrator")]
    //Samo ako je role administrator dopusti pristup
    //[Authorize(Roles ="admin")]
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ApplicationFormController : ControllerBase
    {
        private readonly IApplicationService _applicationService;

        public ApplicationFormController(IApplicationService applicationService)
        {
            this._applicationService = applicationService;
        }
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<ApplicationDto>>>> GetApplications(int? page=1, int? pageSize=10, string? sortBy="name",string? filter="", string? filterType="name")
        {
            
            return Ok(await this._applicationService.GetApplications((int)page, (int)pageSize, sortBy, filter, filterType));
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<ServiceResponse<ApplicationFormDto>>> PostApplication(ApplicationFormDto formData)
        {

            var serviceR = await this._applicationService.PostApplication(formData);
            if (serviceR.Success)
            {
                return Ok(serviceR);
            }
            return BadRequest(serviceR);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<Application>>> GetApplicationById(Guid id)
        {
            var result = await this._applicationService.GetSingleApplication(id);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return NotFound(result);
            }
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<ServiceResponse<Application>>> UpdateApplication(Guid id, ApplicationUpdateDto statusUpdate)
        {
            return Ok(await this._applicationService.UpdateApplication(id, statusUpdate));
        }
        [HttpPost("{id}")]
        public async Task<ActionResult<ServiceResponse<Comment>>> AddApplicationComment([FromBody] ApplicationCommentDto userData, [FromRoute] Guid id)
        {
            return Ok(await this._applicationService.AddApplicationComment(userData,id));
        }

    }
}
