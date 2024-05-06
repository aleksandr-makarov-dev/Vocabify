namespace Vocabify.API.Modules.Accounts.Models
{
    public class UserInfoModel
    {
        public required string Email { get; set; }
        public IEnumerable<string> Roles { get; set; }
    }
}
