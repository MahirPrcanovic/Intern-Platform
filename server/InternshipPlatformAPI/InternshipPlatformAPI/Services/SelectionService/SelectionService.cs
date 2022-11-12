using AutoMapper;
using InternshipPlatformAPI.Data;
using InternshipPlatformAPI.Dtos.SelectionDto;
using InternshipPlatformAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Runtime.CompilerServices;
using System.Security.Claims;

namespace InternshipPlatformAPI.Services.SelectionService
{
    public class SelectionService : ISelectionService
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SelectionService(DataContext dataContext, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _dataContext = dataContext;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
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

        public async Task<ServiceResponse<GetSelectionDto>> EditSelection(Guid id,EditSelectionDto newSelection)
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

        public async Task<ServiceResponse<List<GetSelectionDto>>> GetAllSelections(int pageNumber, int pageSize, string sort, string filterBy)
        {
            IQueryable<Selection> selections;
            switch (sort)
            {
                case "desc":
                    selections = _dataContext.Selections.OrderByDescending(s => s.Name).Skip((pageNumber-1)*pageSize).Take(pageSize).Where(s=>s.Name.Contains(filterBy));
                    break;
                case "asc":
                    selections = _dataContext.Selections.OrderBy(s => s.Name).Skip((pageNumber - 1) * pageSize).Take(pageSize).Where(s => s.Name.Contains(filterBy));
                    break;
                default:
                    selections = _dataContext.Selections.Skip((pageNumber - 1) * pageSize).Take(pageSize).Where(s => s.Name.Contains(filterBy));
                    break;
            }
            var response = new ServiceResponse<List<GetSelectionDto>>();
            var  allSelections = await selections.ToListAsync();

            response.Data = allSelections.Select(c => _mapper.Map<GetSelectionDto>(c)).ToList();
            return response;
            
                  
                
        }
        //selecionDetails
        public async Task<ServiceResponse<GetSelectionDto>> GetSelectionById(Guid selectionId)
        {
            var response = new ServiceResponse<GetSelectionDto>();
            var singleSelection = await _dataContext.Selections.FirstOrDefaultAsync(i => i.Id.Equals(selectionId));

            singleSelection.Applications = await _dataContext.Applications.Where(x => x.Selections.Contains(singleSelection)).ToListAsync();
            var selectionComments = await Task.Run(() => _dataContext.SelectionComments.ToList());
            
            var comms = _dataContext.Comments.ToList();
            
            singleSelection.Comments = _dataContext.Comments.Where(x => selectionComments.Select(y => y.Comment).ToList().Contains(x)).ToList();
            
            if(singleSelection == null) //ako ne pronadje odgovarajucu selekciju pod tim id-em
            {
                response.Success= false;  
                response.Message = "No available selection.";
            }

            response.Data = _mapper.Map<GetSelectionDto> (singleSelection);
            return response;

        }

        public async Task<ServiceResponse<List<GetSelectionDto>>> RemoveSelectionApplicant(Guid selectionId, Guid applicantId)
        {
            ServiceResponse<List<GetSelectionDto>> response = new ServiceResponse<List<GetSelectionDto>>();

            var selection = await _dataContext.Selections.FirstOrDefaultAsync(i => i.Id.Equals(selectionId));
            selection.Applications = await _dataContext.Applications.Where(x => x.Selections.Contains(selection)).ToListAsync();

            if (selection == null)
            {
                response.Success = false;
                response.Message = "Selection not found";
            }

           

          var removeApplicant = selection?.Applications?.Where(a => a.Id.Equals(applicantId)).FirstOrDefault();
            Console.WriteLine(selection);

            if (selection != null && removeApplicant!=null)
            {
                selection?.Applications?.Remove(removeApplicant);
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

         public async Task<ServiceResponse<List<Application>>> AddApplicantToSelection(Guid selectionId, Guid applicantId)
        {
            var response = new ServiceResponse<List<Application>>();
            var newApp= await _dataContext.Applications.Where(a => a.Id == applicantId).FirstOrDefaultAsync();


            if(newApp == null)
            {
                response.Success = false;
                response.Message = "Invalid Id Application";
                    return response;
            }

            var selekcija = await _dataContext.Selections
                .Include(y => y.Applications)
                .Where(x => x.Id == selectionId).FirstOrDefaultAsync();
          

            selekcija.Applications.Add(newApp);
            await _dataContext.SaveChangesAsync();


            response.Data = selekcija.Applications.ToList();
            return response;


        }

        public async Task<ActionResult<ServiceResponse<Comment>>> AddComment(Guid selectionId, SelectionCommentDto comment)
        {
            var response = new ServiceResponse<Comment>();
            var existis = await _dataContext.Selections.FirstOrDefaultAsync(s => s.Id == selectionId);
            var loggedUserId = this._httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var user = await this._dataContext.Users.FirstOrDefaultAsync(x => x.Id == loggedUserId);
            if (existis == null)
            {
                response.Success = false;
                response.Message = "Selection doesn't exists.";
                return response;
            }

            if (user == null)
            {
                response.Success = false;
                response.Message = "User not found.";
                return response;
            }

            var newComment = new Comment()
            {
                CommentText = comment.CommentText
            };

            var addComment = _mapper.Map<Comment>(newComment);
            addComment.DateCreated = DateTime.Now;
            _dataContext.Comments.Add(addComment);

            var selectionComment = new SelectionComment()
            {
                Comment = addComment,
                Selection = existis,
                User = user,
            };

            _dataContext.SelectionComments.Add(selectionComment);
          
            response.Data = addComment;
            await _dataContext.SaveChangesAsync();


            return response;

        }

       
    }
}
