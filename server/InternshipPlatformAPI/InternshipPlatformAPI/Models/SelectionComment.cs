using Microsoft.AspNetCore.Identity;

namespace InternshipPlatformAPI.Models
{
    //FK-ovi se ne moraju definisati (zakomentarisani za referencu)
    public class SelectionComment
    {
        public Guid? Id { get; set; }
        //FK
        //public Guid? SelectionId { get; set; }
        ////FK
        //public Guid? UserId { get; set; }
        ////FK
        //public Guid? CommentId { get; set; }

        public Selection? Selection { get; set; }
        public IdentityUser? User { get; set; }
        public Comment? Comment { get; set; }

    }
}
