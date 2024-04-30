using Vocabify.API.Data.Entities;

namespace Vocabify.API.Modules.Sets.Models
{
    public class SetWithTermsDto
    {
        public Set Set { get; set; }
        public IEnumerable<Term> Terms { get; set; }
    }
}
