using Vocabify.API.Modules.Accounts.Models;

namespace Vocabify.API.Modules.Accounts.Services
{
    public interface IAccountService
    {
        Task RegisterAsync(RegisterModel model);
        Task LoginAsync(LoginModel model);
        Task ConfirmEmailAsync(ConfirmEmailModel model);
        Task LogoutAsync();
        Task<UserInfoModel> GetUserInfoAsync(string id);
        Task<IEnumerable<UserInfoModel>> GetUsersAsync();
    }
}
