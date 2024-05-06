using Vocabify.API.Data.Entities;

namespace Vocabify.API.Modules.Terms.Models
{
    public class CreateTermsModel
    {
        public IEnumerable<CreateTermModel> Terms { get; set; }
    }
}
