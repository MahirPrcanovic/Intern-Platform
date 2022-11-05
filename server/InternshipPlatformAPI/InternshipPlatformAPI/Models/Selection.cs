using System.ComponentModel.DataAnnotations;

namespace InternshipPlatformAPI.Models
{
    public class Selection
    {
       
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        public string Name { get; set; }=string.Empty;
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
        public ICollection<SelectionComment>? Comments { get; set; }
    }
}
