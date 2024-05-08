using Microsoft.AspNetCore.Mvc;
using PuppeteerSharp;
using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Vocabify.API.Data.Entities;
using Vocabify.API.Models;
using Vocabify.API.Modules.Sets.Models;
using Vocabify.API.Modules.Sets.Services;

namespace Vocabify.API.Modules.Sets
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SetsController : ControllerBase
    {
        private readonly ISetsService _setsService;
        private readonly IImportService _importService;

        public SetsController(ISetsService setsService, IImportService importService)
        {
            _setsService = setsService;
            _importService = importService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateSetModel body)
        {
            string userId = User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;

            Guid createdId = await _setsService.CreateAsync(body, userId);

            return Ok(new ObjectId { Id = createdId });
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateSetModel body)
        {
            await _setsService.UpdateAsync(id, body);

            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            await _setsService.DeleteAsync(id);

            return NoContent();
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll([FromQuery] string? search, [FromQuery] int page = 1)
        {
            await Task.Delay(5000);
            string userId = User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;

            Paged<Set> foundSets = await _setsService.GetAllAsync(page,userId,search);  

            return Ok(foundSets);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            Set? foundSet = await _setsService.GetByIdAsync(id);

            if (foundSet == null)
            {
                return NotFound($"Set '{id}' not found");
            }

            return Ok(foundSet);
        }

        [HttpGet("import")]
        public async Task<IActionResult> Import([FromQuery] string url)
        {
            SetWithTermsModel? importedSet = await _importService.FromQuizletAsync(url);

            if (importedSet == null)
            {
                return BadRequest($"Couldn't import quizlet set '{url}'");
            }

            return Ok(importedSet);
        }
    }
}
