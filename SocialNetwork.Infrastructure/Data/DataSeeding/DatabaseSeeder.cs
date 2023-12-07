using Bogus;
using SocialNetwork.Domain.Entities;
using SocialNetwork.Domain.Entities.Enums;
using SocialNetwork.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Infrastructure.Data.DataSeeding
{
    public class DatabaseSeeder : IDisposable
    {
        public IReadOnlyCollection<Profile> Profiles { get; } = new List<Profile>();
        public IReadOnlyCollection<FriendRequest> FriendRequests { get; } = new List<FriendRequest>();
        public IReadOnlyCollection<Friend> Friends { get; } = new List<Friend>();
        public IReadOnlyCollection<Group> Groups { get; } = new List<Group>();
        public IReadOnlyCollection<GroupMember> GroupMembers { get; } = new List<GroupMember>();
        public IReadOnlyCollection<GroupInvitation> GroupInvitations { get; } = new List<GroupInvitation>();
        public IReadOnlyCollection<Page> Pages { get; } = new List<Page>();
        public IReadOnlyCollection<PageFollower> PageFollowers { get; } = new List<PageFollower>();
        public IReadOnlyCollection<ProfilePost> ProfilePosts { get; } = new List<ProfilePost>();
        public IReadOnlyCollection<PagePost> PagePosts { get; } = new List<PagePost>();
        public IReadOnlyCollection<GroupPost> GroupPosts { get; } = new List<GroupPost>();
        public IReadOnlyCollection<Comment> Comments { get; } = new List<Comment>();
        public IReadOnlyCollection<PostReaction> PostReactions { get; } = new List<PostReaction>();
        public IReadOnlyCollection<Chat> Chats { get; } = new List<Chat>();
        public IReadOnlyCollection<ChatParticipant> ChatParticipants { get; } = new List<ChatParticipant>();
        public IReadOnlyCollection<Message> Messages { get; } = new List<Message>();


        public DatabaseSeeder()
        {
            Profiles = GenerateProfiles(amount: 500);
            FriendRequests = GenerateFriendRequests(amount: 2000, Profiles);
            Friends = GenerateFriends(amount: 2000, Profiles);
            Groups = GenerateGroups(amount: 50, Profiles);
            GroupMembers = GenerateGroupMembers(amount: 500, Profiles, Groups);
            GroupInvitations = GenerateGroupInvitations(amount: 500, Profiles, Groups);
            Pages = GeneratePages(amount: 50, Profiles);
            PageFollowers = GeneratePageFollowers(amount: 5000, Profiles, Pages);
            ProfilePosts = GenerateProfilePosts(amount: 2000, Profiles);
            PagePosts = GeneratePagePosts(amount: 500, Pages);
            GroupPosts = GenerateGroupPosts(amount: 2000, Profiles, Groups.Count);
            Comments = GenerateComments(amount: 4000, Profiles, ProfilePosts.Count + PagePosts.Count + GroupPosts.Count);
            PostReactions = GeneratePostReactions(amount: 10000, Profiles, ProfilePosts.Count + PagePosts.Count + GroupPosts.Count);
            Chats = GenerateChats(amount: 500, Profiles);
            ChatParticipants = GenerateChatParticipants(amount: 1000, Profiles, Chats.Count);
            Messages = GenerateMessages(amount: 50000, ChatParticipants, Chats);
        }

        private static IReadOnlyCollection<Profile> GenerateProfiles(int amount)
        {
            var FriendFaker = new Faker<Profile>()
                .UseSeed(1)
                .RuleFor(p => p.ProfileId, f => $"user{f.Random.Number(1, amount)}");


            var userNoIds = 1;

            var profileFaker = new Faker<Profile>()
                .RuleFor(p => p.ProfileId, f => $"user{userNoIds++}")
                .RuleFor(p => p.Gender, f => f.PickRandom<Gender>())
                .RuleFor(p => p.FristName, (f, p) => f.Name.FirstName())
                .RuleFor(p => p.LastName, (f, p) => f.Name.LastName())
                .RuleFor(p => p.Bio, f => f.Random.Words(50))
                .RuleFor(p => p.BirthDate, f => f.Date.Past(30))
                .RuleFor(p => p.PicturePath, f => f.Person.Avatar)
                //.RuleFor(p => p.Friends, f => FriendFaker.Generate(10))
                ;

            var profiles = Enumerable.Range(1, amount)
                .Select(i => SeedRow(profileFaker, i))
                .ToList();

            return profiles;
        }

        private static IReadOnlyCollection<FriendRequest> GenerateFriendRequests(int amount, IEnumerable<Profile> profiles)
        {
            // Now we set up the faker for our join table.
            // We do this by grabbing a random product and category that were generated.
            var FriendRequestFaker = new Faker<FriendRequest>()
                .RuleFor(x => x.SenderProfileID, f => f.PickRandom(profiles).ProfileId)
                .RuleFor(x => x.ReceiverProfileID, f => f.PickRandom(profiles).ProfileId)
                .RuleFor(x => x.FriendRequestStatus, f => f.PickRandom<FriendRequestStatus>());

            var FriendRequests = Enumerable.Range(1, amount)
                .Select(i => SeedRow(FriendRequestFaker, i))
                // We do this GroupBy() + Select() to remove the duplicates
                // from the generated join table entities
                .GroupBy(x => new { x.SenderProfileID, x.ReceiverProfileID })
                .Select(x => x.First())
                .ToList();

            return FriendRequests;
        }
        
        private static IReadOnlyCollection<Friend> GenerateFriends(int amount, IEnumerable<Profile> profiles)
        {
            // Now we set up the faker for our join table.
            // We do this by grabbing a random product and category that were generated.
            var FriendFaker = new Faker<Friend>()
                .RuleFor(x => x.FriendProfileID, f => f.PickRandom(profiles).ProfileId)
                .RuleFor(x => x.ProfileID, f => f.PickRandom(profiles).ProfileId)
                .RuleFor(x => x.StartDate, f => f.Date.Past(3));

            var Friends = Enumerable.Range(1, amount)
                .Select(i => SeedRow(FriendFaker, i))
                // We do this GroupBy() + Select() to remove the duplicates
                // from the generated join table entities
                .GroupBy(x => new { x.FriendProfileID, x.ProfileID })
                .Select(x => x.First())
                .ToList();

            return Friends;
        }

        private static IReadOnlyCollection<Group> GenerateGroups(int amount, IEnumerable<Profile> profiles)
        {
            //var groupId = 1;
            var GroupFaker = new Faker<Group>()
                .RuleFor(x => x.GroupName, f => f.Name.Random.Words(4))
                .RuleFor(x => x.GroupDescription, f => f.Name.Random.Words(100))
                .RuleFor(x => x.CreatorProfileID, f => f.PickRandom(profiles).ProfileId)
                .RuleFor(x => x.CreationDate, f => f.Date.Past(3))
                .RuleFor(x => x.GroupStatus, f => f.PickRandom<GroupStatus>())
                ;

            var Groups = Enumerable.Range(1, amount)
                .Select(i => SeedRow(GroupFaker, i))
                .ToList();

            return Groups;
        }
        private static IReadOnlyCollection<GroupMember> GenerateGroupMembers(int amount, IEnumerable<Profile> profiles, IEnumerable<Group> groups)
        {
            //var groupMemberId = 1;

            var GroupMemberFaker = new Faker<GroupMember>()
                .RuleFor(x => x.GroupID, f => f.Random.Number(1, groups.Count()))
                .RuleFor(x => x.ProfileID, f => f.PickRandom(profiles).ProfileId)
                .RuleFor(x => x.Role, f => f.PickRandom<GroupMemberRole>().OrDefault(f, 0.95f, GroupMemberRole.Member))
                .RuleFor(x => x.JoinDate, (f, gm) => f.Date.Past(1));
            //.RuleFor(x => x.JoinDate, (f,gm) => f.Date.Past(1, groups.FirstOrDefault(x => x.GroupID == gm.GroupID)!.CreationDate));
            ;

            var GroupMembers = Enumerable.Range(1, amount)
                .Select(i => SeedRow(GroupMemberFaker, i))
                .GroupBy(x => new { x.GroupID, x.ProfileID })
                .Select(x => x.First())
                .ToList();

            return GroupMembers;
        }

        private static IReadOnlyCollection<GroupInvitation> GenerateGroupInvitations(int amount, IEnumerable<Profile> profiles, IEnumerable<Group> groups)
        {
            //var groupMemberId = 1;

            var GroupInvitationFaker = new Faker<GroupInvitation>()
                //.RuleFor(x => x.GroupMemberID, f => groupMemberId++)
                .RuleFor(x => x.GroupID, f => f.Random.Number(1, groups.Count()))
                .RuleFor(x => x.InvitedProfileID, f => f.PickRandom(profiles).ProfileId)
                .RuleFor(x => x.InvitedByProfileID, f => f.PickRandom(profiles).ProfileId)
                .RuleFor(x => x.InvitationDate, (f, gm) => f.Date.Past(1))
                .RuleFor(x => x.Status, f => f.PickRandom<InvitationStatus>())
                ;

            var GroupInvitations = Enumerable.Range(1, amount)
                .Select(i => SeedRow(GroupInvitationFaker, i))
                .GroupBy(x => new { x.GroupID, x.InvitedProfileID, x.InvitedByProfileID })
                .Select(x => x.First())
                .ToList();

            return GroupInvitations;
        }

        private static IReadOnlyCollection<Page> GeneratePages(int amount, IEnumerable<Profile> profiles)
        {
            var PageFaker = new Faker<Page>()
                .RuleFor(x => x.PageName, f => f.Name.Random.Words(4))
                .RuleFor(x => x.PageDescription, f => f.Random.Words(100))
                .RuleFor(x => x.CreatorProfileID, f => f.PickRandom(profiles).ProfileId)
                .RuleFor(x => x.CreationDate, f => f.Date.Past(3))
                ;

            var Pages = Enumerable.Range(1, amount)
                .Select(i => SeedRow(PageFaker, i))
                .ToList();

            return Pages;
        }

        private static IReadOnlyCollection<PageFollower> GeneratePageFollowers(int amount, IEnumerable<Profile> profiles, IEnumerable<Page> pages)
        {
            var PageFollowerFaker = new Faker<PageFollower>()
                .RuleFor(x => x.PageID, f => f.Random.Number(1, pages.Count()))
                .RuleFor(x => x.ProfileID, f => f.PickRandom(profiles).ProfileId)
                .RuleFor(x => x.Role, f => f.PickRandom<PageFollowerRole>().OrDefault(f, 0.95f, PageFollowerRole.Member))
                ;

            var PageFollowers = Enumerable.Range(1, amount)
                .Select(i => SeedRow(PageFollowerFaker, i))
                .GroupBy(x => new { x.PageID, x.ProfileID, })
                .Select(x => x.First())
                .ToList();

            return PageFollowers;
        }

        private static IReadOnlyCollection<ProfilePost> GenerateProfilePosts(int amount, IEnumerable<Profile> profiles)
        {
            var ProfilePostFaker = new Faker<ProfilePost>()
                .RuleFor(x => x.Content, f => f.Name.Random.Words(f.Random.Number(5, 50)))
                .RuleFor(x => x.ProfileID, f => f.PickRandom(profiles).ProfileId)
                .RuleFor(x => x.PostDate, f => f.Date.Past(3))
                ;

            var ProfilePosts = Enumerable.Range(1, amount)
                .Select(i => SeedRow(ProfilePostFaker, i))
                .ToList();

            return ProfilePosts;
        }
        private static IReadOnlyCollection<PagePost> GeneratePagePosts(int amount, IEnumerable<Page> pages)
        {
            var PagePostFaker = new Faker<PagePost>()
                .RuleFor(x => x.Content, f => f.Name.Random.Words(f.Random.Number(5, 50)))
                .RuleFor(x => x.PageID, f => f.Random.Number(1, pages.Count()))
                .RuleFor(x => x.PostDate, f => f.Date.Past(3))
                ;

            var PagePosts = Enumerable.Range(1, amount)
                .Select(i => SeedRow(PagePostFaker, i))
                .ToList();

            return PagePosts;
        }

        private static IReadOnlyCollection<GroupPost> GenerateGroupPosts(int amount, IEnumerable<Profile> profiles, int groupsCount)
        {
            var GroupPostFaker = new Faker<GroupPost>()
                .RuleFor(x => x.Content, f => f.Name.Random.Words(f.Random.Number(5, 50)))
                .RuleFor(x => x.ProfileID, f => f.PickRandom(profiles).ProfileId)
                .RuleFor(x => x.GroupID, f => f.Random.Number(1, groupsCount))
                .RuleFor(x => x.PostDate, f => f.Date.Past(3))
                ;

            var GroupPosts = Enumerable.Range(1, amount)
                .Select(i => SeedRow(GroupPostFaker, i))
                .ToList();

            return GroupPosts;
        }

        private static IReadOnlyCollection<Comment> GenerateComments(int amount, IEnumerable<Profile> profiles, int postsCount)
        //private static IReadOnlyCollection<Comment> GenerateComments(int amount, IEnumerable<Profile> profiles, int postId, DateTime postDate)
        {
            var CommentFaker = new Faker<Comment>()
                .RuleFor(x => x.CommentText, f => f.Name.Random.Words(f.Random.Number(5, 50)))
                .RuleFor(x => x.ProfileID, f => f.PickRandom(profiles).ProfileId)
                .RuleFor(x => x.PostID, f => f.Random.Number(1, postsCount))
                .RuleFor(x => x.CommentDate, (f, c) => f.Date.Past(1))
                ;

            var Comments = Enumerable.Range(1, amount)
                .Select(i => SeedRow(CommentFaker, i))
                .ToList();

            return Comments;
        }

        private static IReadOnlyCollection<PostReaction> GeneratePostReactions(int amount, IEnumerable<Profile> profiles, int postsCount)
        {
            var PostReactionFaker = new Faker<PostReaction>()
                .RuleFor(x => x.ProfileID, f => f.PickRandom(profiles).ProfileId)
                .RuleFor(x => x.Type, f => f.PickRandom<ReactionType>())
                .RuleFor(x => x.ReactionDate, (f, c) => f.Date.Past(1))
                .RuleFor(x => x.PostID, f => f.Random.Number(1, postsCount))
                ;

            var PostReactions = Enumerable.Range(1, amount)
                .Select(i => SeedRow(PostReactionFaker, i))
                .ToList();

            return PostReactions;
        }

        private static IReadOnlyCollection<Chat> GenerateChats(int amount, IEnumerable<Profile> profiles)
        {
            var chatId = 1;

            var ChatParticipantFaker = new Faker<ChatParticipant>()
                .RuleFor(x => x.ProfileID, f => f.PickRandom(profiles).ProfileId)
                .RuleFor(x => x.ChatID, f => chatId)
                ;

            //var ChatParticipants = ChatParticipantFaker.Generate(2);

            //var MessageFaker = new Faker<Message>()
            //    .RuleFor(x => x.ChatID, f => chatId)
            //    .RuleFor(x => x.SenderProfileID, f => f.PickRandom(ChatParticipants.ToList().Select(x => x.ProfileID)))
            //    .RuleFor(x => x.MessageText, f => f.Random.Words(10))
            //    .RuleFor(x => x.SendDate, f => f.Date.Past(3))
            //;

            //var messages = GenerateMessages(10, )

            var ChatFaker = new Faker<Chat>()
                .UseSeed(chatId)
                .RuleFor(x => x.StartDate, (f) => f.Date.Past(3))
                //.RuleFor(x => x.Participants, (f, x) => GenerateChatParticipants(2, profiles, chatId).ToList())
                //.RuleFor(x => x.Participants, (f, x) => ChatParticipantFaker.Generate(2))
                //.RuleFor(x => x.Messages, (f, x) => GenerateMessages(10, x.Participants.Select(x => x.ProfileID), chatId).ToList())
                ;

            var Chats = Enumerable.Range(1, amount)
                .Select(i => ChatFaker.Generate())
                .ToList();

            return Chats;
        }


        private static IReadOnlyCollection<ChatParticipant> GenerateChatParticipants(int amount, IEnumerable<Profile> profiles, int chatsCount)
        {

            var ChatParticipantFaker = new Faker<ChatParticipant>()
                //.UseSeed(1)
                .RuleFor(x => x.ProfileID, f => f.PickRandom(profiles).ProfileId)
                //.RuleFor(x => x.ChatID, f => chatId)
                .RuleFor(x => x.ChatID, f => f.Random.Number(1, chatsCount))
                ;

            var ChatParticipants = Enumerable.Range(1, amount)
                .Select(i => ChatParticipantFaker.Generate())
                //.Select(i => SeedRow(ChatParticipantFaker, i))
                .GroupBy(x => new { x.ChatID, x.ProfileID })
                .Select(x => x.First())
                //.SelectMany(x => x.Take(2))
                .ToList();

            return ChatParticipants;
        }

        private static IReadOnlyCollection<Message> GenerateMessages(int amount, IEnumerable<ChatParticipant> chatParticipants, IEnumerable<Chat> chats)
        {
            var MessageFaker = new Faker<Message>()
                .RuleFor(x => x.ChatID, f => f.PickRandom(chatParticipants).ChatID)
                //.RuleFor(x => x.SenderProfileID, (f, m) => f.PickRandom(chats.Where(c => c.Participants.Any(cp => cp.ChatID == m.ChatID)).SelectMany(x => x.Participants)).ProfileID)
                .RuleFor(x => x.SenderProfileID, (f, m) => f.PickRandom(chatParticipants.Where(cp => cp.ChatID == m.ChatID)).ProfileID)
                .RuleFor(x => x.MessageText, f => f.Random.Words(10))
                .RuleFor(x => x.SendDate, f => f.Date.Past(3))

                ;

            var Messages = Enumerable.Range(1, amount)
                .Select(i => SeedRow(MessageFaker, i))
                //.GroupBy(x => new { x.ChatID, x.ProfileID })
                //.Select(x => x.First())
                .ToList();

            return Messages;
        }



        private static T SeedRow<T>(Faker<T> faker, int rowId) where T : class
        {
            var recordRow = faker.UseSeed(rowId).Generate();
            return recordRow;
        }

        public void Dispose()
        {
            this.Dispose();
        }
    }
}
