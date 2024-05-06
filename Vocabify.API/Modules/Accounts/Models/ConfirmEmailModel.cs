using System.ComponentModel.DataAnnotations;

namespace Vocabify.API.Modules.Accounts.Models
{
    public class ConfirmEmailModel
    {
        [Required]
        [EmailAddress]
        public required string Email { get; set; }
    }
}
