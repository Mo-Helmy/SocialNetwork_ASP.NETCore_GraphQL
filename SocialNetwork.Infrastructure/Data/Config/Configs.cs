using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialNetwork.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Infrastructure.Data.Config
{
    internal class ChatConfig : IEntityTypeConfiguration<Chat>
    {
        public void Configure(EntityTypeBuilder<Chat> builder)
        {
            builder.HasOne(x => x.User1)
                .WithMany()
                .HasForeignKey(x => x.User1ID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.User2)
                .WithMany()
                .HasForeignKey(x => x.User2ID)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }

    internal class FriendshipConfig : IEntityTypeConfiguration<Friendship>
    {
        public void Configure(EntityTypeBuilder<Friendship> builder)
        {
            builder.HasOne(x => x.User1)
                .WithMany()
                .HasForeignKey(x => x.User1ID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.User2)
                .WithMany()
                .HasForeignKey(x => x.User2ID)
                .OnDelete(DeleteBehavior.Restrict);

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
}
