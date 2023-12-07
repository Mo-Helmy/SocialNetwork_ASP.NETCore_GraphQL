using Bogus;
using SocialNetwork.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Infrastructure.Data
{
    public class DatabaseIdentitySeeder
    {
        public IReadOnlyCollection<AppUser> Users { get; } = new List<AppUser>();


        public DatabaseIdentitySeeder()
        {
            Users = GenerateUsers(amount: 500);
        }

        private static IReadOnlyCollection<AppUser> GenerateUsers(int amount)
        {
            var userNoIds = 1;
            var userFaker = new Faker<AppUser>()
                 .RuleFor(u => u.Id, f => $"user{userNoIds++}")
                    .RuleFor(u => u.Email, (f, u) => $"{u.Id}@example.com")
                    .RuleFor(u => u.UserName, (f, u) => u.Id)
                    .RuleFor(u => u.EmailConfirmed, f => true)
                    //.RuleFor(u => u.RegistrationDate, (f, u) => f.Date.Past(3))
                    //.RuleFor(u => u.LastLoginDate, (f, u) => f.Date.Past(1, u.RegistrationDate))
                    ;

            var users = Enumerable.Range(1, amount)
                .Select(i => SeedRow(userFaker, i))
                .ToList();

            return users;
        }

        private static T SeedRow<T>(Faker<T> faker, int rowId) where T : class
        {
            var recordRow = faker.UseSeed(rowId).Generate();
            return recordRow;
        }
    }
}
