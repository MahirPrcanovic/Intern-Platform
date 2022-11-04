using AutoMapper;
using InternshipPlatformAPI.Data;
using InternshipPlatformAPI.Dtos.SelectionDto;
using InternshipPlatformAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace InternshipPlatformAPI.Services.SelectionService
{
    public class SelectionService : ISelectionService
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public SelectionService(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetSelectionDto>>> AddSelection(AddSelectionDto newSelection)
        {
            var response = new ServiceResponse<List<GetSelectionDto>>();

            Selection selection = _mapper.Map<Selection>(newSelection);
            _dataContext.Selections.Add(selection);
            await _dataContext.SaveChangesAsync();
             response.Data = await  _dataContext.Selections
                .Select(c => _mapper.Map<GetSelectionDto>(c))
                .ToListAsync();

            return response;
        }

        public async Task<ServiceResponse<GetSelectionDto>> EditSelection(EditSelectionDto newSelection, int id)
        {
            ServiceResponse<GetSelectionDto> response = new ServiceResponse<GetSelectionDto>();
             
            var selection = await _dataContext.Selections.FirstOrDefaultAsync(s=>s.Id.Equals(newSelection.Id));

            if(selection == null)
            {
                response.Success=false;
                response.Message = "Selecion not found";
            }

            _mapper.Map(newSelection, selection);

            await _dataContext.SaveChangesAsync();

            response.Data = _mapper.Map<GetSelectionDto>(selection);

            return response;


        }

        public async Task<ServiceResponse<List<GetSelectionDto>>> GetAllSelections()
        {
            var response = new ServiceResponse<List<GetSelectionDto>>();
            var  allSelections = await _dataContext.Selections.ToListAsync();

            response.Data = allSelections.Select(c => _mapper.Map<GetSelectionDto>(c)).ToList();
            return response;
            
                  
                
        }

        public async Task<ServiceResponse<GetSelectionDto>> GetSelectionById(int selectionId)
        {
            var response = new ServiceResponse<GetSelectionDto>();
            var singleSelection = await _dataContext.Selections.FirstOrDefaultAsync(i => i.Id.Equals(selectionId));
            if(singleSelection == null) //ako ne pronadje odgovarajucu selekciju pod tim id-em
            {
                response.Success= false;
                response.Message = "No available selection.";
            }

            response.Data = _mapper.Map<GetSelectionDto> (singleSelection);
            return response;

        }

        public async Task<ServiceResponse<List<GetSelectionDto>>> RemoveSelectionApplicant(int selectionId, int applicantId)
        {
            ServiceResponse<List<GetSelectionDto>> response = new ServiceResponse<List<GetSelectionDto>>();

            var selection = await _dataContext.Selections
                .FirstOrDefaultAsync(s => s.Id.Equals(selectionId));

          var removeApplicant = await selection.Applications.FirstOrDefaultAsync(a => a.Id.Equals(applicantId));

            if (selection != null && removeApplicant!=null)
            {
                _dataContext.Applications.Remove(removeApplicant);
                await _dataContext.SaveChangesAsync();
                response.Data = _dataContext.Selections
                        .Select(c => _mapper.Map<GetSelectionDto>(c)).ToList();
            }

            else
            {
                response.Success = false;
                response.Message = "Selection no found";
            }

            return response;
        }
    }
}
