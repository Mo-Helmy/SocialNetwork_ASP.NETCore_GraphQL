using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SocialNetwork.API;
using SocialNetwork.Domain.Entities;
using SocialNetwork.Infrastructure.Data;

namespace JobResearchSystem.API.Extensions
{
    public static class UpdateDatabaseExtension
    {
        public static async Task UpdateDatabase(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();

            var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();

            var loggerFactory = scope.ServiceProvider.GetRequiredService<ILoggerFactory>();

            try
            {
                await dbContext.Database.MigrateAsync();

                await AppContextSeed.ApplySeedingAsync(dbContext, userManager, roleManager);
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<Program>();
                logger.LogError(ex, "Database updating failed !");
            }
        }
    }
}
