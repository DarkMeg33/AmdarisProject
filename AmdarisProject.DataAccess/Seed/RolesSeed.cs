using AmdarisProject.Domain.Identity;
using Microsoft.AspNetCore.Identity;

namespace AmdarisProject.DataAccess.Seed
{
    public class RolesSeed
    {
        public static async Task SeedAsync(RoleManager<Role> roleManager)
        {
            if (!roleManager.Roles.Any())
            {
                var adminRole = new Role()
                {
                    Name = "admin",
                    NormalizedName = "ADMIN"
                };

                var userRole = new Role()
                {
                    Name = "user",
                    NormalizedName = "USER"
                };

                await roleManager.CreateAsync(adminRole);
                await roleManager.CreateAsync(userRole);
            }
        }
    }
}
