using SigmaSoftwareTask.CandidateApi.Dtos;
using SigmaSoftwareTask.CandidateApi.Models;

namespace SigmaSoftwareTask.CandidateApi.Mappers
{
    public class CandidateMapper : ICandidateMapper
    {
        public Candidate? ToCandidate(CandidateDto candidateDto)
        {
            if (candidateDto == null)
            {
                return null;
            }

            return new Candidate
            {
                FirstName = candidateDto.FirstName,
                LastName = candidateDto.LastName,
                PhoneNumber = candidateDto.PhoneNumber,
                Email = candidateDto.Email,
                CallTimeInterval = candidateDto.CallTimeInterval,
                LinkedInUrl = candidateDto.LinkedInUrl,
                GitHubUrl = candidateDto.GitHubUrl,
                FreeTextComment = candidateDto.FreeTextComment
            };
        }

        public CandidateDto ToCandidateDto(Candidate candidate)
        {
            if (candidate == null)
            {
                return null;
            }

            return new CandidateDto
            {
                FirstName = candidate.FirstName,
                LastName = candidate.LastName,
                PhoneNumber = candidate.PhoneNumber,
                Email = candidate.Email,
                CallTimeInterval = candidate.CallTimeInterval,
                LinkedInUrl = candidate.LinkedInUrl,
                GitHubUrl = candidate.GitHubUrl,
                FreeTextComment = candidate.FreeTextComment
            };
        }
    }
}
