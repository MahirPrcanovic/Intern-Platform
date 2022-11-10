namespace InternshipPlatformAPI.Dtos.SelectionDto
{
    public class SelectionCommentDto
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string CommentText { get; set; } = string.Empty;
    }
}
