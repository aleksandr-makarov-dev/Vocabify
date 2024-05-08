using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Vocabify.API.Data.Entities;
using Vocabify.API.Modules.Accounts.Models;

namespace Vocabify.API.Data
{
    public static class DbInitializer
    {
        public static async Task Seed(IServiceScope scope)
        {

            ApplicationDbContext context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            await context.Database.EnsureCreatedAsync();

            // create roles
            RoleManager<IdentityRole> roleManager =
                scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            if (!await roleManager.RoleExistsAsync(Roles.Admin))
            {
                await roleManager.CreateAsync(new IdentityRole(Roles.Admin));
            }

            if (!await roleManager.RoleExistsAsync(Roles.User))
            {
                await roleManager.CreateAsync(new IdentityRole(Roles.User));
            }

            UserManager<IdentityUser> userManager =
                scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

            IdentityUser? user = await userManager.Users.FirstOrDefaultAsync();

            if (!await context.Sets.AnyAsync() && user != null)
            {
                for (int i = 0; i < 100; i++)
                {
                    await context.Sets.AddAsync(new Set
                    {
                        Title = $"My set title {i + 1}",
                        TextLang = "fi",
                        DefinitionLang = "ru",
                        Description = $"My set description {i + 1}",
                        UserId = user.Id
                    });
                }

                await context.SaveChangesAsync();
            }
        }
    }
}
