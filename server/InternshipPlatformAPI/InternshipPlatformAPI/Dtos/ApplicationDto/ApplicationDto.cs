namespace InternshipPlatformAPI.Dtos.ApplicationDto
{
    public class ApplicationDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string EducationLevel { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
    }
}
