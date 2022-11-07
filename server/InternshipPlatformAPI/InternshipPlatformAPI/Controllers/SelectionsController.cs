using AutoMapper;
using InternshipPlatformAPI.Data;
using InternshipPlatformAPI.Dtos.SelectionDto;
using InternshipPlatformAPI.Models;
using InternshipPlatformAPI.Services.SelectionService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Formats.Asn1;

namespace InternshipPlatformAPI.Controllers
{
   // [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SelectionsController : ControllerBase
    {
      
        private  readonly ISelectionService _selectionService;

        public SelectionsController( ISelectionService selection)
        {
            _selectionService = selection;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetSelectionDto>>>> GetAllSelections(string? sort="")
        {
          
            return Ok(await _selectionService.GetAllSelections(sort));
        }

        [HttpGet("GetSelectionsById/{id}")]
        public async Task<ActionResult<ServiceResponse<GetSelectionDto>>>GetSelectionById(Guid id)
        {
            return Ok(await _selectionService.GetSelectionById(id));
        }

        [HttpPost("AddNewSelection")]
        public async Task<ActionResult<ServiceResponse<List<GetSelectionDto>>>>AddSelection([FromBody] AddSelectionDto newSelection)
        {
            return Ok(await _selectionService.AddSelection(newSelection));
        }

        [HttpPut("EditSelection/{id}" )]
        public async Task<ActionResult<ServiceResponse<GetSelectionDto>>>EditSelection([FromBody] EditSelectionDto editSelection, Guid id)
        {
            return Ok(await _selectionService.EditSelection(editSelection, id));
        }
        

        [HttpDelete("DeleteApplicants/{selectionId}/{applicationId}")]
        public async Task<ActionResult<ServiceResponse<List<GetSelectionDto>>>> RemoveSelectionApplicant(Guid selecionId,Guid applicationId)
        {
            return Ok(await _selectionService.RemoveSelectionApplicant(selecionId, applicationId));
        }

        [HttpPost("AddNewApplicantToSelection/{selectionId}/{applicantId}")]
        public async Task<ActionResult<ServiceResponse<List<GetSelectionDto>>>> AddNewApplicantToSelection(Guid selectionId,Guid applicantId)
        {
            return Ok(await _selectionService.AddApplicantToSelection(selectionId,applicantId));
        }
    }
}
