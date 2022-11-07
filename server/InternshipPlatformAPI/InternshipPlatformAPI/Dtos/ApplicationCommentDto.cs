namespace InternshipPlatformAPI.Dtos
{
    public class ApplicationCommentDto
    {
        public Guid Id { get; set; }
        public string userId { get; set; }
        public string CommentText { get; set; } = string.Empty;
    }
}
