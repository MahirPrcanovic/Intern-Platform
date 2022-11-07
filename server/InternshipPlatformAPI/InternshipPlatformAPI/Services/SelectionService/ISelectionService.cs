using InternshipPlatformAPI.Dtos.SelectionDto;
using InternshipPlatformAPI.Models;

namespace InternshipPlatformAPI.Services.SelectionService
{
    public interface ISelectionService
    {
        public Task<ServiceResponse<List<GetSelectionDto>>> GetAllSelections(int pageNumber, int pageSize, string sort);
        public Task<ServiceResponse<GetSelectionDto>> GetSelectionById(Guid selectionId);  
        public Task<ServiceResponse<List<GetSelectionDto>>> AddSelection(AddSelectionDto newSelection);
        public Task<ServiceResponse<List<GetSelectionDto>>> RemoveSelectionApplicant(Guid selectionId, Guid applicationId);
        public Task<ServiceResponse<GetSelectionDto>> EditSelection(EditSelectionDto newSelection, Guid id);
        public Task<ServiceResponse<List<Application>>> AddApplicantToSelection(Guid selectionId,Guid applicantId);
    }
}
