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
        public async Task<ActionResult<ServiceResponse<List<GetSelectionDto>>>> GetAllSelections()
        {
          
            return Ok(await _selectionService.GetAllSelections());
        }

        [HttpGet("{id}", Name = "GetSelectionById")]
        public async Task<ActionResult<ServiceResponse<GetSelectionDto>>>GetSelectionById(int id)
        {
            return Ok(await _selectionService.GetSelectionById(id));
        }

        [HttpPost("AddNewSelection")]
        public async Task<ActionResult<ServiceResponse<List<GetSelectionDto>>>>AddSelection([FromBody] AddSelectionDto newSelection)
        {
            return Ok(await _selectionService.AddSelection(newSelection));
        }

        [HttpPut("{id}", Name ="EditSelection" )]
        public async Task<ActionResult<ServiceResponse<GetSelectionDto>>>EditSelection([FromBody] EditSelectionDto editSelection, int id)
        {
            return Ok(await _selectionService.EditSelection(editSelection, id));
        }
        //provjeriti kako treba ruu definisai

        [HttpDelete("DeleteApplicants")]
        public async Task<ActionResult<ServiceResponse<List<GetSelectionDto>>>> RemoveSelectionApplicant(int selecionId,int applicationId)
        {
            return Ok(await _selectionService.RemoveSelectionApplicant(selecionId, applicationId));
        }

    }
}
