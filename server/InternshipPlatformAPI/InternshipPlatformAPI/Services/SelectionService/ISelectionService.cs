using InternshipPlatformAPI.Dtos.SelectionDto;
using InternshipPlatformAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace InternshipPlatformAPI.Services.SelectionService
{
    public interface ISelectionService
    {
        public Task<ServiceResponse<List<GetSelectionDto>>> GetAllSelections(int pageNumber, int pageSize, string sort, string filterBy);
        public Task<ServiceResponse<GetSelectionDto>> GetSelectionById(Guid selectionId);  
        public Task<ServiceResponse<List<GetSelectionDto>>> AddSelection(AddSelectionDto newSelection);
        public Task<ServiceResponse<List<GetSelectionDto>>> RemoveSelectionApplicant(Guid selectionId, Guid applicationId);
        public Task<ServiceResponse<GetSelectionDto>> EditSelection(Guid id, EditSelectionDto newSelection);
        public Task<ServiceResponse<List<Application>>> AddApplicantToSelection(Guid selectionId,Guid applicantId);
        public Task<ActionResult<ServiceResponse<Comment>>> AddComment(Guid selectionId, SelectionCommentDto comment);
    }
}
