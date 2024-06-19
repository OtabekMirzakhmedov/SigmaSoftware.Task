using Microsoft.AspNetCore.Mvc;
using SigmaSoftwareTask.CandidateApi.Dtos;
using SigmaSoftwareTask.CandidateApi.Mappers;
using SigmaSoftwareTask.CandidateApi.Models;
using SigmaSoftwareTask.CandidateApi.Services;

namespace SigmaSoftwareTask.CandidateApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CandidatesController : ControllerBase
    {
        private readonly ICandidateService _candidateService;
        private readonly ICandidateMapper _candidateMapper;

        public CandidatesController(ICandidateService candidateService, ICandidateMapper candidateMapper)
        {
            _candidateService = candidateService;
            _candidateMapper = candidateMapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Candidate>>> GetAllCandidates()
        {
            var candidates = await _candidateService.GetAllCandidatesAsync();
            return Ok(candidates);

        }

            [HttpPost]
        public async Task<IActionResult> AddOrUpdateCandidateAsync(CandidateDto candidateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var candidate = _candidateMapper.ToCandidate(candidateDto);
            await _candidateService.AddOrUpdateCandidateAsync(candidate);
            return Ok();
        }
    }
}
