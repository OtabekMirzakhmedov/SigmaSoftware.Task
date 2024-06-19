using System.ComponentModel.DataAnnotations;

namespace SigmaSoftwareTask.CandidateApi.Dtos
{
    public class CandidateDto
    {
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string LastName { get; set; } = string.Empty;

        [Phone]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        public string CallTimeInterval { get; set; } = string.Empty;

        [Url]
        public string? LinkedInUrl { get; set; }

        [Url]
        public string? GitHubUrl { get; set; }

        [Required]
        public string FreeTextComment { get; set; } = string.Empty;
    }
}
