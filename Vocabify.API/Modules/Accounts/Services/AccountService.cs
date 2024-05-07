using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Vocabify.API.Modules.Accounts.Models;
using Vocabify.API.Modules.Core.Exceptions;

namespace Vocabify.API.Modules.Accounts.Services;

public class AccountService : IAccountService
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;

    public AccountService(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public async Task RegisterAsync(RegisterModel model)
    {
        IdentityUser? foundUser = await _userManager.FindByEmailAsync(model.Email);

        if (foundUser != null)
        {
            throw new UnauthorizedException($"Email '{model.Email}' is already registered");
        }

        IdentityUser userToCreate = new IdentityUser
        {
            UserName = model.Email,
            Email = model.Email
        };

        bool isFirst = !(await _userManager.Users.AnyAsync());


        if (isFirst)
        {
            userToCreate.EmailConfirmed = true;
        }

        IdentityResult createResult = await _userManager.CreateAsync(userToCreate, model.Password);

        if (!createResult.Succeeded)
        {
            throw new DomainException($"Failed to create user:{string.Join("; ",createResult.Errors.Select(e => e.Description))}");
        }

        IdentityResult addToRoleResult = await _userManager.AddToRoleAsync(userToCreate, isFirst ? Roles.Admin : Roles.User);

        if (!addToRoleResult.Succeeded)
        {
            throw new DomainException(
                $"Failed to assign user to role: {string.Join("; ", addToRoleResult.Errors.Select(e => e.Description))}");
        }
    }

    public async Task ConfirmEmailAsync(ConfirmEmailModel model)
    {
        IdentityUser? foundUser = await _userManager.FindByEmailAsync(model.Email);

        if (foundUser == null)
        {
            throw new UnauthorizedAccessException($"Email '{model.Email}' is already registered");
        }

        foundUser.EmailConfirmed = true;

        IdentityResult updateResult = await _userManager.UpdateAsync(foundUser);

        if (!updateResult.Succeeded)
        {
            throw new DomainException($"Failed to confirm email '{model.Email}'");
        }
    }

    public async Task LoginAsync(LoginModel model)
    {
        IdentityUser? foundUser = await _userManager.FindByEmailAsync(model.Email);

        if (foundUser == null)
        {
            throw new NotFoundException($"User '{model.Email}' not found");
        }

        SignInResult signInResult = await _signInManager.PasswordSignInAsync(
            foundUser, 
            model.Password,
            isPersistent:true,
            lockoutOnFailure:true
        );

        if (signInResult.IsLockedOut)
        {
            throw new UnauthorizedAccessException("You account is locked out. Try again later");
        }

        if (signInResult.IsNotAllowed)
        {
            throw new UnauthorizedException(
                "Your account is not verified. Wait for administrator to verify your account");
        }

        if (!signInResult.Succeeded)
        {
            throw new UnauthorizedException("Invalid email or password");
        }
    }

    public async Task LogoutAsync()
    {
        await _signInManager.SignOutAsync();
    }

    public async Task<UserInfoModel> GetUserInfoAsync(string id)
    {
        IdentityUser? foundUser = await _userManager.FindByIdAsync(id);

        if (foundUser == null)
        {
            throw new NotFoundException($"User not found");
        }

        IList<string> roles = await _userManager.GetRolesAsync(foundUser);

        UserInfoModel userInfo = new UserInfoModel
        {
            Email = foundUser.Email,
            Roles = roles
        };

        return userInfo;
    }

    public async Task<IEnumerable<UserInfoModel>> GetUsersAsync()
    {
        IEnumerable<IdentityUser> foundUsers = await _userManager.Users.Where(u => !u.EmailConfirmed).ToListAsync();

        var userInfos = await foundUsers
            .ToAsyncEnumerable()
            .SelectAwait(async (u) =>
            {
                IEnumerable<string> roles = await _userManager.GetRolesAsync(u);
                return new UserInfoModel
                {
                    Email = u.Email,
                    Roles = roles
                };
            })
            .ToListAsync();

        return userInfos;
    }

    public async Task ChangePasswordAsync(ChangePasswordModel model, string? role = null)
    {
        IdentityUser? foundUser = await _userManager.FindByEmailAsync(model.Email);

        if (foundUser == null)
        {
            throw new NotFoundException($"User '{model.Email}' not found");
        }


    }
}