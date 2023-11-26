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
    internal class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasMany(x => x.Chats)
                .WithMany()
                .UsingEntity<ChatParticipant>();

            builder.HasMany(x => x.Friends)
                .WithMany()
                .UsingEntity<Friendship>(
                    l => l.HasOne(x => x.SenderUser).WithMany(x => x.FriendshipsSend).HasForeignKey(x => x.SenderUserID),
                    r => r.HasOne(x => x.ReceiverUser).WithMany(x => x.FriendshipsReceived).HasForeignKey(x => x.ReceiverUserID)
                );

            builder.UseTptMappingStrategy();
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
                .HasKey(cp => new { cp.UserID, cp.ChatID });

            builder
                .HasOne(cp => cp.User)
                .WithMany(u => u.ChatParticipants)
                .HasForeignKey(cp => cp.UserID);

            builder
                .HasOne(cp => cp.Chat)
                .WithMany(c => c.Participants)
                .HasForeignKey(cp => cp.ChatID);

        }
    }

    internal class FriendshipConfig : IEntityTypeConfiguration<Friendship>
    {
        public void Configure(EntityTypeBuilder<Friendship> builder)
        {
            builder.HasOne(x => x.SenderUser)
                .WithMany(x => x.FriendshipsSend)
                .HasForeignKey(x => x.SenderUserID)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.ReceiverUser)
                .WithMany(x => x.FriendshipsReceived)
                .HasForeignKey(x => x.ReceiverUserID)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }

    internal class GroupMemberConfig : IEntityTypeConfiguration<GroupMember>
    {
        public void Configure(EntityTypeBuilder<GroupMember> builder)
        {
            builder.HasOne(x => x.User)
                .WithMany(x => x.GroupMemberships)
                .HasForeignKey(x => x.UserID)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
    
    internal class GroupInvitationConfig : IEntityTypeConfiguration<GroupInvitation>
    {
        public void Configure(EntityTypeBuilder<GroupInvitation> builder)
        {
            builder.HasOne(x => x.InvitedUser)
                .WithMany(x => x.SentGroupInvitations)
                .HasForeignKey(x => x.InvitedUserID)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.InvitedByUser)
                .WithMany(x => x.ReceivedGroupInvitations)
                .HasForeignKey(x => x.InvitedByUserID)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
