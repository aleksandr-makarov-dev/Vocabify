using Vocabify.API.Data.Entities;
using Vocabify.API.Models;
using Vocabify.API.Modules.Sets.Models;

namespace Vocabify.API.Modules.Sets.Services;

public interface ISetsService
{
    Task<Guid> CreateAsync(CreateSetModel dto, string userId);
    Task UpdateAsync(Guid id, UpdateSetModel dto);
    Task DeleteAsync(Guid id);
    Task<Paged<Set>> GetAllAsync(int page, string userId, string? search);
    Task<Set?> GetByIdAsync(Guid id);
}