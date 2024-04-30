using Microsoft.AspNetCore.Mvc;
using PuppeteerSharp;
using System;
using Vocabify.API.Modules.Sets.Models;
using Vocabify.API.Modules.Sets.Services;

namespace Vocabify.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
        public async Task<IActionResult> Create([FromBody] CreateSetDto body)
        {
            Guid createdId = await _setsService.CreateAsync(body);

            return Ok(new { id = createdId });
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateSetDto body)
        {
            await _setsService.UpdateAsync(id, body);

            return NoContent();
        }

        [HttpGet("imports/quizlet")]
        public async Task<IActionResult> ImportFromQuizlet([FromQuery] string q = "https://quizlet.com/ru/862377961/sm2-kpl-1-terveiset-turkista-s-11-flash-cards")
        {
            SetWithTermsDto? importedSet = await _importService.FromQuizletAsync(q);

            if (importedSet == null)
            {
                return BadRequest($"Couldn't import quizlet set '{q}'");
            }

            return Ok(importedSet);
        }
    }
}
