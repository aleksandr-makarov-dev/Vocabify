using Vocabify.API.Modules.Terms.Models;

namespace Vocabify.API.Modules.Terms.Services;

public interface ITermsService
{
    Task<Guid> CreateAsync(CreateTermDto dto);
    Task UpdateAsync(Guid id, UpdateTermDto dto);
    Task DeleteAsync(Guid id);
}