using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vocabify.API.Data.Entities;
using Vocabify.API.Modules.Terms.Models;
using Vocabify.API.Modules.Terms.Services;

namespace Vocabify.API.Modules.Terms
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TermsController : ControllerBase
    {
        private readonly ITermsService _termsService;

        public TermsController(ITermsService termsService)
        {
            _termsService = termsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] Guid setId)
        {
            IEnumerable<Term> foundTerms = await _termsService.GetBySetIdAsync(setId);

            return Ok(foundTerms);
        }

        [HttpPost("bulk")]
        public async Task<IActionResult> CreateBulk([FromBody] CreateTermsModel body)
        {
            IEnumerable<Guid> createdIds = await _termsService.CreateRangeAsync(body.Terms);

            return Ok(createdIds);
        }
    }
}
