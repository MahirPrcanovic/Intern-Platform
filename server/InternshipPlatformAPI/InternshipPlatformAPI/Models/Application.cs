using System.ComponentModel.DataAnnotations;

namespace InternshipPlatformAPI.Models
{
    public class Application
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string EducationLevel { get; set; } = string.Empty;
        [Required]
        [MaxLength(300)]
        public string CoverLetter { get; set; } = string.Empty;
        [Required]
        public string CV { get; set; } = string.Empty;
        [Required]
        public string Status { get; set; } = "applied";
     
        public ICollection<ApplicationComment>? Comments { get; set; }
       
        public ICollection<Selection>? Selections { get; set; }
    }
}
