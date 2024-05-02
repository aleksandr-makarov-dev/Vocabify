using Vocabify.API.Data.Entities;

namespace Vocabify.API.Modules.Terms.Models
{
    public class CreateTermsDto
    {
        public IEnumerable<CreateTermDto> Terms { get; set; }
    }
}
