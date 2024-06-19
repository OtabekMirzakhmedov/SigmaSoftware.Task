using System.Collections.Generic;
using System.Threading.Tasks;
using SigmaSoftwareTask.CandidateApi.Models;

namespace SigmaSoftwareTask.CandidateApi.Services
{
    public interface ICandidateService
    {
        Task AddOrUpdateCandidateAsync(Candidate candidate);
        Task<IEnumerable<Candidate>> GetAllCandidatesAsync();
    }
}
