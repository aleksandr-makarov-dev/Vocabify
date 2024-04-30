using System.ComponentModel.DataAnnotations;

namespace Vocabify.API.Data.Entities
{
    public class EntityBase
    {
        [Key]
        public Guid Id { get; set; }
    }
}
