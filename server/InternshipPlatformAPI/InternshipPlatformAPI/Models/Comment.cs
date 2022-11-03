using System.ComponentModel.DataAnnotations;

namespace InternshipPlatformAPI.Models
{
    public class Comment
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        [MaxLength(255)]
        public string CommentText { get; set; } = string.Empty;
        [Required]
        public DateTime DateCreated { get; set; }
    }
}
