using System.ComponentModel.DataAnnotations;

namespace Vocabify.API.Modules.Accounts.Models
{
    public class RegisterModel
    {
        [Required]
        [EmailAddress]  
        public required string Email { get; set; }
        [Required]
        [MinLength(6)]
        public required string Password { get; set; }
    }
}
