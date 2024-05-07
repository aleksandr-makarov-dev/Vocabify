using System.ComponentModel.DataAnnotations;

namespace Vocabify.API.Modules.Accounts.Models
{
    public class ChangePasswordModel
    {
        [Required]
        [EmailAddress]
        public required string Email { get; set; }
        public string OldPassword { get; set; }
        [Required]
        [MinLength(6)]
        public required string NewPassword { get; set; }
    }
}
