using InternshipPlatformAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace InternshipPlatformAPI.Dtos.SelectionDto
{
    public class GetSelectionDto
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        [MaxLength(255)]
        public string Description { get; set; } = string.Empty;
        //Jedna selekcija moze imati vise aplikanata
        public ICollection<Application>? Applications { get; set; }
        //Jedna selekcija moze imati vise komentara
        public ICollection<Comment>? Comments { get; set; }
    }
}
