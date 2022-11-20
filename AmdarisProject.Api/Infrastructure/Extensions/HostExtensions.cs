using AmdarisProject.DataAccess.Contexts;
using AmdarisProject.DataAccess.Seed;
using AmdarisProject.Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AmdarisProject.Api.Infrastructure.Extensions
{
    public static class HostExtensions
    {
        public static async void SeedData(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<HostelDbContext>();
                    var userManager = services.GetRequiredService<UserManager<User>>();
                    var roleManager = services.GetRequiredService<RoleManager<Role>>();

                    await context.Database.MigrateAsync();

                    await RolesSeed.SeedAsync(roleManager);
                    await UsersSeed.SeedAsync(userManager);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occured during migration");
                }
            }
        }
    }
}
