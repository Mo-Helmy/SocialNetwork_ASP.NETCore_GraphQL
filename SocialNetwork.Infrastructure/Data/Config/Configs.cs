using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialNetwork.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Infrastructure.Data.Config
{
    internal class ProfileConfig : IEntityTypeConfiguration<Profile>
    {
        public void Configure(EntityTypeBuilder<Profile> builder)
        {
            builder.HasKey(x => x.ProfileId);

            builder.HasMany(x => x.Chats)
                .WithMany()
                .UsingEntity<ChatParticipant>();

            builder.HasMany(x => x.Friends)
                .WithMany()
                .UsingEntity<Friend>(
                        r => r.HasOne(x => x.FriendProfile).WithMany().HasForeignKey(x => x.FriendProfileID),
                        l => l.HasOne(x => x.Profile).WithMany().HasForeignKey(x => x.ProfileID)
                );

            //builder.HasMany(x => x.Friends)
            //    .WithMany()
            //    .UsingEntity(j => j.ToTable("UserFriends"));

            //builder.HasMany(x => x.Friends)
            //    .WithMany()
            //    .UsingEntity<FriendRequest>(
            //        l => l.HasOne(x => x.SenderProfile).WithMany(x => x.FriendRequestsSend).HasForeignKey(x => x.SenderProfileID),
            //        r => r.HasOne(x => x.ReceiverProfile).WithMany(x => x.FriendRequestsReceived).HasForeignKey(x => x.ReceiverProfileID)
            //    );

        }
    }

    internal class FriendRequestConfig : IEntityTypeConfiguration<FriendRequest>
    {
        public void Configure(EntityTypeBuilder<FriendRequest> builder)
        {
            builder.HasIndex(x => new { x.SenderProfileID, x.ReceiverProfileID }).IsUnique();

            builder.HasOne(x => x.SenderProfile)
                .WithMany(x => x.FriendRequestsSend)
                .HasForeignKey(x => x.SenderProfileID)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.ReceiverProfile)
                .WithMany(x => x.FriendRequestsReceived)
                .HasForeignKey(x => x.ReceiverProfileID)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }

    internal class FriendConfig : IEntityTypeConfiguration<Friend>
    {
        public void Configure(EntityTypeBuilder<Friend> builder)
        {
            builder.HasIndex(x => new { x.FriendProfileID, x.ProfileID }).IsUnique();

            builder.HasOne(x => x.Profile)
                .WithOne()
                .HasForeignKey<Friend>(x => x.ProfileID);

            builder.HasOne(x => x.FriendProfile)
                .WithMany()
                .HasForeignKey(x => x.FriendProfileID);

        }
    }

    internal class ChatConfig : IEntityTypeConfiguration<Chat>
    {
        public void Configure(EntityTypeBuilder<Chat> builder)
        {


        }
    }

    internal class ChatParticipantConfig : IEntityTypeConfiguration<ChatParticipant>
    {
        public void Configure(EntityTypeBuilder<ChatParticipant> builder)
        {
            builder
                .HasKey(cp => new { cp.ProfileID, cp.ChatID });

            builder
                .HasOne(cp => cp.Profile)
                .WithMany(u => u.ChatParticipants)
                .HasForeignKey(cp => cp.ProfileID);

            builder
                .HasOne(cp => cp.Chat)
                .WithMany(c => c.Participants)
                .HasForeignKey(cp => cp.ChatID);

        }
    }


    internal class GroupConfig : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            //builder.Property(x => x.GroupID).ValueGeneratedNever();
        }
    }

    internal class GroupMemberConfig : IEntityTypeConfiguration<GroupMember>
    {
        public void Configure(EntityTypeBuilder<GroupMember> builder)
        {
            builder.HasOne(x => x.Profile)
                .WithMany(x => x.GroupMemberships)
                .HasForeignKey(x => x.ProfileID)
                .OnDelete(DeleteBehavior.Restrict);

            //builder.Property(x => x.GroupMemberID).ValueGeneratedNever();
        }
    }
    
    internal class GroupInvitationConfig : IEntityTypeConfiguration<GroupInvitation>
    {
        public void Configure(EntityTypeBuilder<GroupInvitation> builder)
        {
            builder.HasOne(x => x.InvitedProfile)
                .WithMany(x => x.SentGroupInvitations)
                .HasForeignKey(x => x.InvitedProfileID)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.InvitedByProfile)
                .WithMany(x => x.ReceivedGroupInvitations)
                .HasForeignKey(x => x.InvitedByProfileID)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }

    internal class PostMediaConfig : IEntityTypeConfiguration<PostMedia>
    {
        public void Configure(EntityTypeBuilder<PostMedia> builder)
        {
            builder.HasOne(x => x.Post)
                .WithMany(x => x.Medias)
                .HasForeignKey(x => x.PostID)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }

    internal class PostReactionConfig : IEntityTypeConfiguration<PostReaction>
    {
        public void Configure(EntityTypeBuilder<PostReaction> builder)
        {
            builder.HasOne(x => x.Post)
                .WithMany(x => x.PostReactions)
                .HasForeignKey(x => x.PostID)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
