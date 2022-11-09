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

        private readonly ISelectionService _selectionService;

        public SelectionsController(ISelectionService selection)
        {
            _selectionService = selection;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetSelectionDto>>>> GetAllSelections(int? pageNumber = 1, int? pageSize = 5, string? sort = "", string? filterBy = "")
        {

            return Ok(await _selectionService.GetAllSelections((int)pageNumber, (int)pageSize, sort, filterBy));
        }

        [HttpGet("GetSelectionsById/{id}")]
        public async Task<ActionResult<ServiceResponse<GetSelectionDto>>> GetSelectionById(Guid id)
        {
            return Ok(await _selectionService.GetSelectionById(id));
        }

        [HttpPost("AddNewSelection")]
        public async Task<ActionResult<ServiceResponse<List<GetSelectionDto>>>> AddSelection([FromBody] AddSelectionDto newSelection)
        {
            return Ok(await _selectionService.AddSelection(newSelection));
        }

        [HttpPut("EditSelection/{id}")]
        public async Task<ActionResult<ServiceResponse<GetSelectionDto>>> EditSelection(Guid id, [FromBody]  EditSelectionDto editSelection)
        {
            return Ok(await _selectionService.EditSelection(id,editSelection));
        }
        

        [HttpDelete("DeleteApplicants/{selectionId}/{applicationId}")]
        public async Task<ActionResult<ServiceResponse<List<GetSelectionDto>>>> RemoveSelectionApplicant(Guid selectionId,Guid applicationId)
        {
            return Ok(await _selectionService.RemoveSelectionApplicant(selectionId, applicationId));
        }

        [HttpPost("AddNewApplicantToSelection/{selectionId}/{applicantId}")]
        public async Task<ActionResult<ServiceResponse<List<GetSelectionDto>>>> AddNewApplicantToSelection(Guid selectionId,Guid applicantId)
        {
            return Ok(await _selectionService.AddApplicantToSelection(selectionId,applicantId));
        }

        [HttpPost("AddNewCommentToSelection/{selectionId}")]
        public async Task<ActionResult<ServiceResponse<Comment>>>AddComment(Guid selectionId, SelectionCommentDto comment)
        {
            return Ok(await _selectionService.AddComment(selectionId,comment));
        }
    }
}
