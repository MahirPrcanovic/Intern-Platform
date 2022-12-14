using InternshipPlatformAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace InternshipPlatformAPI.Dtos.SelectionDto
{
    public class AddApplicantDto
    {
        public Guid Id { get; set; } = Guid.NewGuid();

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
        //IQueryable zbog spasavanja resursa prije queryanju 
        //svaka aplikacija moze imati vise komentara
        public IQueryable<ApplicationComment>? Comments { get; set; }
        //aplikant moze biti u jednoj ili vise selekcija
        public ICollection<Selection>? Selections { get; set; }
    }
}
