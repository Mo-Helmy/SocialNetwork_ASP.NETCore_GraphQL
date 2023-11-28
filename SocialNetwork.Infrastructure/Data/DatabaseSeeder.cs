using Bogus;
using SocialNetwork.Domain.Entities;
using SocialNetwork.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Bogus.DataSets.Name;

namespace SocialNetwork.Infrastructure.Data
{
    public class DatabaseSeeder
    {
        public IReadOnlyCollection<User> Users { get; } = new List<User>();
        public IReadOnlyCollection<Profile> Profiles { get; } = new List<Profile>();
        public IReadOnlyCollection<Friendship> Friendships { get; } = new List<Friendship>();
        public IReadOnlyCollection<Group> Groups { get; } = new List<Group>();
        public IReadOnlyCollection<GroupMember> GroupMembers { get; } = new List<GroupMember>();
        public IReadOnlyCollection<GroupInvitation> GroupInvitations { get; } = new List<GroupInvitation>();
        public IReadOnlyCollection<Page> Pages { get; } = new List<Page>();
        public IReadOnlyCollection<PageFollower> PageFollowers { get; } = new List<PageFollower>();

        public DatabaseSeeder()
        {
            Users = GenerateUsers(amount: 500);
            Profiles = GenerateProfiles(amount: 500);
            Friendships = GenerateFriendships(amount: 2000, Users);
            Groups = GenerateGroups(amount: 50, Users);
            GroupMembers = GenerateGroupMembers(amount: 500, Users, Groups);
            GroupInvitations = GenerateGroupInvitations(amount: 500, Users, Groups);
            Pages = GeneratePages(amount: 50, Users);
            PageFollowers = GeneratePageFollowers(amount: 5000, Users, Pages);
        }

        private static IReadOnlyCollection<User> GenerateUsers(int amount)
        {
            var userNoIds = 1;
            var userFaker = new Faker<User>()
                 .RuleFor(u => u.Id, f => $"user{userNoIds++}")
                    .RuleFor(u => u.Email, (f, u) => $"{u.Id}@example.com")
                    .RuleFor(u => u.UserName, (f, u) => u.Id)
                    .RuleFor(u => u.RegistrationDate, (f, u) => f.Date.Past(3))
                    .RuleFor(u => u.LastLoginDate, (f, u) => f.Date.Past(1, u.RegistrationDate))
                    ;

            var users = Enumerable.Range(1, amount)
                .Select(i => SeedRow(userFaker, i))
                .ToList();

            return users;
        }

        private static IReadOnlyCollection<Profile> GenerateProfiles(int amount)
        {
            var userNoIds = 1;

            var profileFaker = new Faker<Profile>()
                .RuleFor(p => p.UserId, f => $"user{userNoIds++}")
                .RuleFor(p => p.Gender, f => f.PickRandom<Domain.Entities.Enums.Gender>())
                .RuleFor(p => p.FristName, (f, p) => f.Name.FirstName())
                .RuleFor(p => p.LastName, (f, p) => f.Name.LastName())
                .RuleFor(p => p.Bio, f => f.Random.Words(50))
                .RuleFor(p => p.BirthDate, f => f.Date.Past(30))
                .RuleFor(p => p.PicturePath, f => f.Person.Avatar)
                ;

            var profiles = Enumerable.Range(1, amount)
                .Select(i => SeedRow(profileFaker, i))
                .ToList();

            return profiles;
        }

        private static IReadOnlyCollection<Friendship> GenerateFriendships(int amount, IEnumerable<User> users)
        {
            // Now we set up the faker for our join table.
            // We do this by grabbing a random product and category that were generated.
            var FriendshipFaker = new Faker<Friendship>()
                .RuleFor(x => x.SenderUserID, f => f.PickRandom(users).Id)
                .RuleFor(x => x.ReceiverUserID, f => f.PickRandom(users).Id)
                .RuleFor(x => x.FriendshipStatus, f => f.PickRandom<FriendshipStatus>());

            var Friendships = Enumerable.Range(1, amount)
                .Select(i => SeedRow(FriendshipFaker, i))
                // We do this GroupBy() + Select() to remove the duplicates
                // from the generated join table entities
                .GroupBy(x => new { x.SenderUserID, x.ReceiverUserID })
                .Select(x => x.First())
                .ToList();

            return Friendships;
        }

        private static IReadOnlyCollection<Group> GenerateGroups(int amount, IEnumerable<User> users)
        {
            //var groupId = 1;
            var GroupFaker = new Faker<Group>()
                //.RuleFor(x => x.GroupID, f => groupId++)
                .RuleFor(x => x.GroupName, f => f.Name.Random.Words(4))
                .RuleFor(x => x.GroupDescription, f => f.Name.Random.Words(100))
                .RuleFor(x => x.CreatorUserID, f => f.PickRandom(users).Id)
                .RuleFor(x => x.CreationDate, f => f.Date.Past(3))
                .RuleFor(x => x.GroupStatus, f => f.PickRandom<GroupStatus>())
                ;

            var Groups = Enumerable.Range(1, amount)
                .Select(i => SeedRow(GroupFaker, i))
                .ToList();

            return Groups;
        }
        private static IReadOnlyCollection<GroupMember> GenerateGroupMembers(int amount, IEnumerable<User> users, IEnumerable<Group> groups)
        {
            //var groupMemberId = 1;

            var GroupMemberFaker = new Faker<GroupMember>()
                //.RuleFor(x => x.GroupMemberID, f => groupMemberId++)
                .RuleFor(x => x.GroupID, f => f.Random.Number(1, groups.Count()))
                .RuleFor(x => x.UserID, f => f.PickRandom(users).Id)
                .RuleFor(x => x.Role, f => f.PickRandom<GroupMemberRole>().OrDefault(f, 0.95f, GroupMemberRole.Member))
                .RuleFor(x => x.JoinDate, (f,gm) => f.Date.Past(1));
                //.RuleFor(x => x.JoinDate, (f,gm) => f.Date.Past(1, groups.FirstOrDefault(x => x.GroupID == gm.GroupID)!.CreationDate));
                ;

            var GroupMembers = Enumerable.Range(1, amount)
                .Select(i => SeedRow(GroupMemberFaker, i))
                .GroupBy(x => new { x.GroupID, x.UserID })
                .Select(x => x.First())
                .ToList();

            return GroupMembers;
        }
        
        private static IReadOnlyCollection<GroupInvitation> GenerateGroupInvitations(int amount, IEnumerable<User> users, IEnumerable<Group> groups)
        {
            //var groupMemberId = 1;

            var GroupInvitationFaker = new Faker<GroupInvitation>()
                //.RuleFor(x => x.GroupMemberID, f => groupMemberId++)
                .RuleFor(x => x.GroupID, f => f.Random.Number(1, groups.Count()))
                .RuleFor(x => x.InvitedUserID, f => f.PickRandom(users).Id)
                .RuleFor(x => x.InvitedByUserID, f => f.PickRandom(users).Id)
                .RuleFor(x => x.InvitationDate, (f,gm) => f.Date.Past(1))
                .RuleFor(x => x.Status, f => f.PickRandom<InvitationStatus>())
                ;

            var GroupInvitations = Enumerable.Range(1, amount)
                .Select(i => SeedRow(GroupInvitationFaker, i))
                .GroupBy(x => new { x.GroupID, x.InvitedUserID, x.InvitedByUserID })
                .Select(x => x.First())
                .ToList();

            return GroupInvitations;
        }

        private static IReadOnlyCollection<Page> GeneratePages(int amount, IEnumerable<User> users)
        {
            var PageFaker = new Faker<Page>()
                .RuleFor(x => x.PageName, f => f.Name.Random.Words(4))
                .RuleFor(x => x.PageDescription, f => f.Random.Words(100))
                .RuleFor(x => x.CreatorUserID, f => f.PickRandom(users).Id)
                .RuleFor(x => x.CreationDate, f => f.Date.Past(3))
                ;

            var Pages = Enumerable.Range(1, amount)
                .Select(i => SeedRow(PageFaker, i))
                .ToList();

            return Pages;
        }

        private static IReadOnlyCollection<PageFollower> GeneratePageFollowers(int amount, IEnumerable<User> users, IEnumerable<Page> pages)
        {
            var PageFollowerFaker = new Faker<PageFollower>()
                .RuleFor(x => x.PageID, f => f.Random.Number(1, pages.Count()))
                .RuleFor(x => x.UserID, f => f.PickRandom(users).Id)
                .RuleFor(x => x.Role, f => f.PickRandom<PageFollowerRole>().OrDefault(f, 0.95f, PageFollowerRole.Member))

                ;

            var PageFollowers = Enumerable.Range(1, amount)
                .Select(i => SeedRow(PageFollowerFaker, i))
                .GroupBy(x => new { x.PageID, x.UserID,})
                .Select(x => x.First())
                .ToList();

            return PageFollowers;
        }

        private static T SeedRow<T>(Faker<T> faker, int rowId) where T : class
        {
            var recordRow = faker.UseSeed(rowId).Generate();
            return recordRow;
        }
    }
}
