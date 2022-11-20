using System.Security.Claims;
using AmdarisProject.Domain.Identity;
using Microsoft.AspNetCore.Identity;

namespace AmdarisProject.DataAccess.Seed
{
    public class UsersSeed
    {
        public static async Task SeedAsync(UserManager<User> userManager)
        {
            if (!userManager.Users.Any())
            {
                var admin = new User()
                {
                    UserName = "admin",
                    Email = "admin@admin.com",
                };

                var user = new User()
                {
                    UserName = "user",
                    Email = "user@user.com",
                };

                await userManager.CreateAsync(admin, "admin");
                await userManager.CreateAsync(user, "user");

                await userManager.AddToRoleAsync(admin, "admin");
                await userManager.AddToRoleAsync(user, "user");
            }
        }
    }
}
