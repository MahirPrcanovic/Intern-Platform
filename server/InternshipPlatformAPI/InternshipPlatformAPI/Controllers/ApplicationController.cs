using InternshipPlatformAPI.Dtos.ApplicationDto;
using InternshipPlatformAPI.Services.ApplicationService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InternshipPlatformAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ApplicationController : ControllerBase
    {
        private readonly IApplicationService _applicationService;

        public ApplicationController(IApplicationService applicationService)
        {
            this._applicationService = applicationService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int? page=1, int? pageSize=10, string? sortBy="name",string? filter="", string? filterType="name")
        {
            return Ok(await this._applicationService.Get((int)page, (int)pageSize, sortBy, filter, filterType));
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Post(ApplicationFormDto formData)
        {
            var response = await this._applicationService.Post(formData);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await this._applicationService.Get(id);
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
        public async Task<IActionResult> Update(Guid id, ApplicationUpdateDto statusUpdate)
        {
            return Ok(await this._applicationService.Update(id, statusUpdate));
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> PostComment([FromBody] ApplicationCommentDto userData, [FromRoute] Guid id)
        {
            return Ok(await this._applicationService.PostComment(userData,id));
        }

    }
}
