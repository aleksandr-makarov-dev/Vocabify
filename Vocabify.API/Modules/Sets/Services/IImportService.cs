using Vocabify.API.Data.Entities;
using Vocabify.API.Modules.Sets.Models;

namespace Vocabify.API.Modules.Sets.Services
{
    public interface IImportService
    {
        Task<SetWithTermsModel?> FromFileAsync(IFormFile file);
    }
}
