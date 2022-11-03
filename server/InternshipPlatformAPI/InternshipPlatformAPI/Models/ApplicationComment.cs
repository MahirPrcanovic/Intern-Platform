using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace InternshipPlatformAPI.Models
{
    //FK-ovi se ne moraju definisati (zakomentarisani za referencu)
    public class ApplicationComment
    {
        public Guid? Id { get; set; } = Guid.NewGuid();

        //FK
        //public Guid? UserId { get; set; }
        //FK
        //public Guid? ApplicationId { get; set; }
        //FK
        //public Guid? CommentId { get; set; }
        public IdentityUser? User { get; set; }

        public Comment? Comment { get; set; }
        public Application? Application { get; set; }
    }
}
