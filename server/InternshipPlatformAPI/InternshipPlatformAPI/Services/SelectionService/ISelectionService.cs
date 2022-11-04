using InternshipPlatformAPI.Dtos.SelectionDto;
using InternshipPlatformAPI.Models;

namespace InternshipPlatformAPI.Services.SelectionService
{
    public interface ISelectionService
    {
        public Task<ServiceResponse<List<GetSelectionDto>>> GetAllSelections();
        public Task<ServiceResponse<GetSelectionDto>> GetSelectionById(int selectionId);  
        public Task<ServiceResponse<List<GetSelectionDto>>> AddSelection(AddSelectionDto newSelection);
        public Task<ServiceResponse<List<GetSelectionDto>>> RemoveSelectionApplicant(int selectionId, int applicationId);
        public Task<ServiceResponse<GetSelectionDto>> EditSelection(EditSelectionDto newSelection, int id);
    }
}
