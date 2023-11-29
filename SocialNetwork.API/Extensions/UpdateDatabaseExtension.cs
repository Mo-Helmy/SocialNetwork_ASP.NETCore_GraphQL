using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SocialNetwork.API;
using SocialNetwork.Domain.Entities.Identity;
using SocialNetwork.Infrastructure.Data;
using SocialNetwork.Infrastructure.Data.DataSeeding;
using SocialNetwork.Infrastructure.Identity;

namespace SocialNetwork.API.Extensions
{
    public static class UpdateDatabaseExtension
    {
        public static async Task UpdateDatabase(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();

            var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            var identityDbContext = scope.ServiceProvider.GetRequiredService<AppIdentityDbContext>();

            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();

            var loggerFactory = scope.ServiceProvider.GetRequiredService<ILoggerFactory>();

            try
            {
                // ensure identity database created
                await identityDbContext.Database.MigrateAsync();
                await AppIdentityContextSeed.ApplySeedingAsync(userManager, roleManager);

                // ensure app database created
                await dbContext.Database.MigrateAsync();
                await AppContextSeed.ApplySeedingAsync(dbContext);
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<Program>();
                logger.LogError(ex, "Database updating failed !");
            }
        }
    }
}
