using Vocabify.API.Data.Entities;
using Vocabify.API.Modules.Terms.Models;

namespace Vocabify.API.Modules.Terms.Services;

public interface ITermsService
{
    Task<Guid> CreateAsync(CreateTermModel dto);
    Task UpdateAsync(Guid id, UpdateTermModel dto);
    Task DeleteAsync(Guid id);
    Task<IEnumerable<Term>> GetBySetIdAsync(Guid setId);
    Task<IEnumerable<Guid>> CreateRangeAsync(IEnumerable<CreateTermModel> list);
}