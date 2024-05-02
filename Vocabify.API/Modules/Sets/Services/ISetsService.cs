using Vocabify.API.Data.Entities;
using Vocabify.API.Modules.Sets.Models;

namespace Vocabify.API.Modules.Sets.Services;

public interface ISetsService
{
    Task<Guid> CreateAsync(CreateSetDto dto);
    Task UpdateAsync(Guid id, UpdateSetDto dto);
    Task DeleteAsync(Guid id);
    Task<IEnumerable<Set>> GetAllAsync();
    Task<Set?> GetByIdAsync(Guid id);
}