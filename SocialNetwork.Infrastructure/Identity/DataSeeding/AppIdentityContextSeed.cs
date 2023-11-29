using Microsoft.AspNetCore.Identity;
using SocialNetwork.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Infrastructure.Data
{
    public static class AppIdentityContextSeed
    {
        public static async Task ApplySeedingAsync(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            var dataSeeder = new DatabaseIdentitySeeder();

            if (!userManager.Users.Any())
            {
                foreach (var user in dataSeeder.Users)
                {
                    await userManager.CreateAsync(user, "string123");
                }
            }
        }
    }
}
