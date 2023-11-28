using Bogus;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SocialNetwork.Domain.Entities;
using SocialNetwork.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Infrastructure.Data
{
    public static class AppContextSeed
    {



        public static async Task ApplySeedingAsync(AppDbContext dbContext, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            var maxUsersCount = 100;
            var maxGroupsCount = 10;

            var dataSeeder = new DatabaseSeeder();



            if (!dbContext.Users.Any())
            {
                //var userNoIds = 1;
                //var randomUser = new Faker<User>()
                //    .RuleFor(u => u.Id, f => $"user{userNoIds++}")
                //    .RuleFor(u => u.Email, (f, u) => $"{u.Id}@example.com")
                //    .RuleFor(u => u.UserName, (f, u) => u.Id);

                //foreach (var user in randomUser.Generate(maxUsersCount).ToList())
                //{
                //    await userManager.CreateAsync(user, "string123");
                //}
                foreach (var user in dataSeeder.Users)
                {
                    await userManager.CreateAsync(user, "string123");
                }
            }

            if (!dbContext.Profiles.Any())
            {
                //var userNoIds = 1;

                //var randomProfile = new Faker<Profile>()
                //    .RuleFor(p => p.UserId, f => $"user{userNoIds++}")
                //    .RuleFor(p => p.Gender, f => f.PickRandom<Gender>())
                //    .RuleFor(p => p.FristName, (f, p) => f.Name.FirstName())
                //    .RuleFor(p => p.LastName, (f, p) => f.Name.LastName())
                //    .RuleFor(p => p.Bio, f => f.Random.Words(50))
                //    .RuleFor(p => p.BirthDate, f => f.Date.Past(30))
                //    .RuleFor(p => p.PicturePath, f => f.Person.Avatar)
                //    ;

                //await dbContext.Set<Profile>().AddRangeAsync(randomProfile.Generate(maxUsersCount).ToList());
                await dbContext.Set<Profile>().AddRangeAsync(dataSeeder.Profiles);

                await dbContext.SaveChangesAsync();
            }

            if (!dbContext.Friendships.Any())
            {
                //var randomFriendship = new Faker<Friendship>()
                //    .RuleFor(x => x.SenderUserID, f => $"user{f.Random.Number(1, maxUsersCount)}")
                //    .RuleFor(x => x.ReceiverUserID, f => $"user{f.Random.Number(1 , maxUsersCount)}")
                //    .RuleFor(x => x.FriendshipStatus, f => f.PickRandom<FriendshipStatus>());

                //var xx = randomFriendship.Generate(200).ToList();


                await dbContext.Set<Friendship>().AddRangeAsync(dataSeeder.Friendships);


                await dbContext.SaveChangesAsync();

            }


            if (!dbContext.Groups.Any())
            {
                //var groupMemberRandom = new Faker<GroupMember>()
                //    .RuleFor(x => x.GroupID, f => f.Random.Number(1, maxGroupsCount))
                //    .RuleFor(x => x.UserID, f => $"user{f.Random.Number(1, maxUsersCount)}")
                //    .RuleFor(x => x.Role, f => f.Random.Words(1))
                //    .RuleFor(x => x.JoinDate, f => f.Date.Past(3));



                //var randomGroup = new Faker<Group>()
                //    .RuleFor(x => x.GroupName, f => f.Name.Random.Words(4))
                //    .RuleFor(x => x.GroupDescription, f => f.Name.Random.Words(100))
                //    .RuleFor(x => x.CreatorUserID, f => $"user{f.Random.Number(1, maxUsersCount)}")
                //    .RuleFor(x => x.CreationDate, f => f.Date.Past(3))
                //    .RuleFor(x => x.GroupStatus, f => f.PickRandom<GroupStatus>())
                //    .RuleFor(x => x.GroupMembers, f => groupMemberRandom.Generate(new Random().Next(10, 50)))
                //    ;

                //foreach (var group in randomGroup.Generate(maxGroupsCount).ToList())
                //{
                //    await dbContext.Set<Group>().AddAsync(group);
                //    await dbContext.SaveChangesAsync();
                //}

                await dbContext.Set<Group>().AddRangeAsync(dataSeeder.Groups);

                await dbContext.SaveChangesAsync();
            }

            if (!dbContext.GroupMembers.Any())
            {
                await dbContext.Set<GroupMember>().AddRangeAsync(dataSeeder.GroupMembers);

                await dbContext.SaveChangesAsync();
            }

            if (!dbContext.GroupInvitations.Any())
            {
                await dbContext.Set<GroupInvitation>().AddRangeAsync(dataSeeder.GroupInvitations);

                await dbContext.SaveChangesAsync();
            }

            if (!dbContext.Pages.Any())
            {
                await dbContext.Set<Page>().AddRangeAsync(dataSeeder.Pages);

                await dbContext.SaveChangesAsync();
            }

            if (!dbContext.PageFollowers.Any())
            {
                await dbContext.Set<PageFollower>().AddRangeAsync(dataSeeder.PageFollowers);

                await dbContext.SaveChangesAsync();
            }
        }
    }
}
