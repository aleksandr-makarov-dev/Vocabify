using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Vocabify.API.Data.Entities
{
    public class Set:EntityBase
    {
        [Required]
        [MaxLength(150)]
        public required string Title { get; set; }
        [MaxLength(300)]
        public required string Description { get; set; }
        [MaxLength(300)]
        public string? Image { get; set; }
        [Required]
        [MaxLength(50)]
        public required string TextLang { get; set; }
        [Required]
        [MaxLength(50)]
        public required string DefinitionLang { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string UserId { get; set; }
        public IdentityUser User { get; set; }
        public List<Term> Terms { get; set; }
    }
}
