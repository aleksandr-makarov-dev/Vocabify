using Vocabify.API.Data.Entities;

namespace Vocabify.API.Modules.Sets.Models
{
    public class SetWithTermsModel
    {
        public required string Title { get; set; }
        public required string Description { get; set; }
        public string? Image { get; set; }
        public required string TextLang { get; set; }
        public required string DefinitionLang { get; set; }
        public IEnumerable<Term> Terms { get; set; }
    }
}
