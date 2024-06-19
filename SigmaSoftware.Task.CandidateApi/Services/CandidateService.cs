using Microsoft.EntityFrameworkCore;
using SigmaSoftwareTask.CandidateApi.Data;
using SigmaSoftwareTask.CandidateApi.Models;

namespace SigmaSoftwareTask.CandidateApi.Services
{
    public class CandidateService: ICandidateService
    {
        private readonly AppDbContext _context;

        public CandidateService(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddOrUpdateCandidateAsync(Candidate candidate)
        {
            var existingCandidate = await _context.Candidates
                .FirstOrDefaultAsync(c => c.Email == candidate.Email);

            if (existingCandidate != null)
            {
                existingCandidate.FirstName = candidate.FirstName;
                existingCandidate.LastName = candidate.LastName;
                existingCandidate.PhoneNumber = candidate.PhoneNumber;
                existingCandidate.CallTimeInterval = candidate.CallTimeInterval;
                existingCandidate.LinkedInUrl = candidate.LinkedInUrl;
                existingCandidate.GitHubUrl = candidate.GitHubUrl;
                existingCandidate.FreeTextComment = candidate.FreeTextComment;

                _context.Candidates.Update(existingCandidate);
            }
            else
            {
                _context.Candidates.Add(candidate);
            }

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Candidate>> GetAllCandidatesAsync()
        {
            return await _context.Candidates.ToListAsync();
        }
    }
}
