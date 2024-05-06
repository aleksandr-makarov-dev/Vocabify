using Vocabify.API.Data.Entities;
using Vocabify.API.Modules.Sets.Models;

namespace Vocabify.API.Modules.Sets.Services;

public interface ISetsService
{
    Task<Guid> CreateAsync(CreateSetModel dto);
    Task UpdateAsync(Guid id, UpdateSetModel dto);
    Task DeleteAsync(Guid id);
    Task<IEnumerable<Set>> GetAllAsync(int page, string? search);
    Task<Set?> GetByIdAsync(Guid id);
}