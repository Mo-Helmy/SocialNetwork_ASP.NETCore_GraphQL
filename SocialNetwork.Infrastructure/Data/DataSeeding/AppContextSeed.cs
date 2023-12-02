using Microsoft.AspNetCore.Identity;
using SocialNetwork.Domain.Entities;
using SocialNetwork.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Infrastructure.Data.DataSeeding
{
    public static class AppContextSeed
    {
        private static readonly DatabaseSeeder dataSeeder = new DatabaseSeeder();

        public static async Task ApplySeedingAsync(AppDbContext dbContext)
        {
            //var dataSeeder = new DatabaseSeeder();

            if (!dbContext.Profiles.Any())
            {
                await dbContext.Set<Profile>().AddRangeAsync(dataSeeder.Profiles);

                await dbContext.SaveChangesAsync();
            }

            if (!dbContext.Friendships.Any())
            {
                await dbContext.Set<Friendship>().AddRangeAsync(dataSeeder.Friendships);

                await dbContext.SaveChangesAsync();
            }

            if (!dbContext.Friends.Any())
            {
                await dbContext.Set<Friend>().AddRangeAsync(dataSeeder.Friends);

                await dbContext.SaveChangesAsync();
            }


            if (!dbContext.Groups.Any())
            {
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


            if (!dbContext.ProfilePosts.Any())
            {
                await dbContext.Set<ProfilePost>().AddRangeAsync(dataSeeder.ProfilePosts);

                await dbContext.SaveChangesAsync();
            }

            if (!dbContext.PagePosts.Any())
            {
                await dbContext.Set<PagePost>().AddRangeAsync(dataSeeder.PagePosts);

                await dbContext.SaveChangesAsync();
            }

            if (!dbContext.GroupPosts.Any())
            {
                await dbContext.Set<GroupPost>().AddRangeAsync(dataSeeder.GroupPosts);

                await dbContext.SaveChangesAsync();
            }


            if (!dbContext.Comments.Any())
            {
                await dbContext.Set<Comment>().AddRangeAsync(dataSeeder.Comments);

                await dbContext.SaveChangesAsync();
            }

            if (!dbContext.PostReactions.Any())
            {
                await dbContext.Set<PostReaction>().AddRangeAsync(dataSeeder.PostReactions);

                await dbContext.SaveChangesAsync();
            }

            if (!dbContext.Chats.Any())
            {
                await dbContext.Set<Chat>().AddRangeAsync(dataSeeder.Chats);

                await dbContext.SaveChangesAsync();
            }

            if (!dbContext.ChatParticipants.Any())
            {
                await dbContext.Set<ChatParticipant>().AddRangeAsync(dataSeeder.ChatParticipants);

                await dbContext.SaveChangesAsync();
            }

            if (!dbContext.Messages.Any())
            {
                await dbContext.Set<Message>().AddRangeAsync(dataSeeder.Messages);

                await dbContext.SaveChangesAsync();
            }
        }
    }
}
