using SigmaSoftwareTask.CandidateApi.Dtos;
using SigmaSoftwareTask.CandidateApi.Models;

namespace SigmaSoftwareTask.CandidateApi.Mappers
{
    public interface ICandidateMapper
    {
        Candidate ToCandidate(CandidateDto candidateDto);
        CandidateDto ToCandidateDto(Candidate candidate);
    }
}
