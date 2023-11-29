using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SocialNetwork.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Profile> Profiles { get; set; }

        public DbSet<Friendship> Friendships { get; set; }

        public DbSet<Group> Groups { get; set; }
        public DbSet<GroupMember> GroupMembers { get; set; }
        public DbSet<GroupInvitation> GroupInvitations { get; set; }

        public DbSet<Page> Pages { get; set; }
        public DbSet<PageFollower> PageFollowers { get; set; }

        public DbSet<Post> Posts { get; set; }
        public DbSet<ProfilePost> ProfilePosts { get; set; }
        public DbSet<PagePost> PagePosts { get; set; }
        public DbSet<GroupPost> GroupPosts { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Media> Medias { get; set; }
        public DbSet<PostMedia> PostMedias { get; set; }
        public DbSet<CommentMedia> CommentMedias { get; set; }
        public DbSet<MessageMedia> MessageMedias { get; set; }

        public DbSet<Reaction> Reactions { get; set; }
        public DbSet<PostReaction> PostReactions { get; set; }
        public DbSet<CommentReaction> CommentReactions { get; set; }
        public DbSet<MessageReaction> MessageReactions { get; set; }

        public DbSet<PostHashtag> PostHashtags { get; set; }
        public DbSet<Hashtag> Hashtags { get; set; }

        public DbSet<Chat> Chats { get; set; }
        public DbSet<ChatParticipant> ChatParticipants { get; set; }
        public DbSet<Message> Messages { get; set; }

        public DbSet<Notification> Notifications { get; set; }
        

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
