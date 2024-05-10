using Microsoft.AspNetCore.Mvc;
using PuppeteerSharp;
using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Vocabify.API.Data.Entities;
using Vocabify.API.Models;
using Vocabify.API.Modules.Core.Exceptions;
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

        [HttpPost("import")]
        public async Task<IActionResult> Import(IFormFile file)
        {

            if (file.Length > 2097152)
            {
                throw new BadRequestException("Max file size is 2 megabytes");
            }

            if (file.ContentType != "text/html")
            {
                throw new BadRequestException("Only 'text/html' file type is allowed");
            }

            SetWithTermsModel? importedSet = await _importService.FromFileAsync(file);

            if (importedSet == null)
            {
                throw new NotFoundException("Failed to import set from the file");
            }

            return Ok(importedSet);
        }
    }
}
