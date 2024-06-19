﻿using System.ComponentModel.DataAnnotations;

namespace SigmaSoftware.Task.CandidateApi.Models
{
    public class Candidate
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string LastName { get; set; } = string.Empty;

        [Phone]
        [StringLength(15)]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; } = string.Empty;

        [StringLength(100)]
        public string CallTimeInterval { get; set; } = string.Empty;

        [Url]
        [StringLength(200)]
        public string LinkedInUrl { get; set; } = string.Empty;

        [Url]
        [StringLength(200)]
        public string GitHubUrl { get; set; } = string.Empty;

        [Required]
        [StringLength(1000)]
        public string FreeTextComment { get; set; } = string.Empty;
    }
}