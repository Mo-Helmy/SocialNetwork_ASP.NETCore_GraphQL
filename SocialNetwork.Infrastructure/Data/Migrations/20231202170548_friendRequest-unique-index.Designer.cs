﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SocialNetwork.Infrastructure.Data;

#nullable disable

namespace SocialNetwork.Infrastructure.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20231202170548_friendRequest-unique-index")]
    partial class friendRequestuniqueindex
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SocialNetwork.Domain.Entities.Chat", b =>
                {
                    b.Property<int>("ChatID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ChatID"));

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ChatID");

                    b.ToTable("Chats");
                });

            modelBuilder.Entity("SocialNetwork.Domain.Entities.ChatParticipant", b =>
                {
                    b.Property<string>("ProfileID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("ChatID")
                        .HasColumnType("int");

                    b.HasKey("ProfileID", "ChatID");

                    b.HasIndex("ChatID");

                    b.ToTable("ChatParticipants");
                });

            modelBuilder.Entity("SocialNetwork.Domain.Entities.Comment", b =>
                {
                    b.Property<int>("CommentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CommentID"));

                    b.Property<DateTime>("CommentDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CommentText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PostID")
                        .HasColumnType("int");

                    b.Property<string>("ProfileID")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("CommentID");

                    b.HasIndex("PostID");

                    b.HasIndex("ProfileID");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("SocialNetwork.Domain.Entities.Friend", b =>
                {
                    b.Property<int>("FriendID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FriendID"));

                    b.Property<string>("FriendProfileID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProfileID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("FriendID");

                    b.HasIndex("ProfileID");

                    b.HasIndex("FriendProfileID", "ProfileID")
                        .IsUnique()
                        .HasFilter("[FriendProfileID] IS NOT NULL AND [ProfileID] IS NOT NULL");

                    b.ToTable("Friends");
                });

            modelBuilder.Entity("SocialNetwork.Domain.Entities.FriendRequest", b =>
                {
                    b.Property<int>("FriendRequestID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FriendRequestID"));

                    b.Property<int>("FriendRequestStatus")
                        .HasColumnType("int");

                    b.Property<string>("ReceiverProfileID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SenderProfileID")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("FriendRequestID");

                    b.HasIndex("ReceiverProfileID");

                    b.HasIndex("SenderProfileID", "ReceiverProfileID")
                        .IsUnique()
                        .HasFilter("[SenderProfileID] IS NOT NULL AND [ReceiverProfileID] IS NOT NULL");

                    b.ToTable("FriendRequests");
                });

            modelBuilder.Entity("SocialNetwork.Domain.Entities.Group", b =>
                {
                    b.Property<int>("GroupID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GroupID"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatorProfileID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("GroupDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GroupName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GroupStatus")
                        .HasColumnType("int");

                    b.HasKey("GroupID");

                    b.HasIndex("CreatorProfileID");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("SocialNetwork.Domain.Entities.GroupInvitation", b =>
                {
                    b.Property<int>("GroupInvitationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GroupInvitationID"));

                    b.Property<int>("GroupID")
                        .HasColumnType("int");

                    b.Property<DateTime>("InvitationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("InvitedByProfileID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("InvitedProfileID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("GroupInvitationID");

                    b.HasIndex("GroupID");

                    b.HasIndex("InvitedByProfileID");

                    b.HasIndex("InvitedProfileID");

                    b.ToTable("GroupInvitations");
                });

            modelBuilder.Entity("SocialNetwork.Domain.Entities.GroupMember", b =>
                {
                    b.Property<int>("GroupMemberID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GroupMemberID"));

                    b.Property<int>("GroupID")
                        .HasColumnType("int");

                    b.Property<DateTime>("JoinDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ProfileID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.HasKey("GroupMemberID");

                    b.HasIndex("GroupID");

                    b.HasIndex("ProfileID");

                    b.ToTable("GroupMembers");
                });

            modelBuilder.Entity("SocialNetwork.Domain.Entities.Hashtag", b =>
                {
                    b.Property<int>("HashtagID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HashtagID"));

                    b.Property<string>("HashtagText")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("HashtagID");

                    b.ToTable("Hashtags");
                });

            modelBuilder.Entity("SocialNetwork.Domain.Entities.Media", b =>
                {
                    b.Property<int>("MediaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MediaID"));

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Path")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfileId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<DateTime>("UploadDate")
                        .HasColumnType("datetime2");

                    b.HasKey("MediaID");

                    b.HasIndex("ProfileId");

                    b.ToTable("Medias");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Media");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("SocialNetwork.Domain.Entities.Message", b =>
                {
                    b.Property<int>("MessageID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MessageID"));

                    b.Property<int>("ChatID")
                        .HasColumnType("int");

                    b.Property<string>("MessageText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("SendDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("SenderProfileID")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("MessageID");

                    b.HasIndex("ChatID");

                    b.HasIndex("SenderProfileID");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("SocialNetwork.Domain.Entities.Notification", b =>
                {
                    b.Property<int>("NotificationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NotificationID"));

                    b.Property<bool>("IsRead")
                        .HasColumnType("bit");

                    b.Property<DateTime>("NotificationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("NotificationText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfileID")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("NotificationID");

                    b.HasIndex("ProfileID");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("SocialNetwork.Domain.Entities.Page", b =>
                {
                    b.Property<int>("PageID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PageID"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatorProfileID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PageDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PageName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PageID");

                    b.HasIndex("CreatorProfileID");

                    b.ToTable("Pages");
                });

            modelBuilder.Entity("SocialNetwork.Domain.Entities.PageFollower", b =>
                {
                    b.Property<int>("PageFollowerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PageFollowerID"));

                    b.Property<int>("PageID")
                        .HasColumnType("int");

                    b.Property<string>("ProfileID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.HasKey("PageFollowerID");

                    b.HasIndex("PageID");

                    b.HasIndex("ProfileID");

                    b.ToTable("PageFollowers");
                });

            modelBuilder.Entity("SocialNetwork.Domain.Entities.Post", b =>
                {
                    b.Property<int>("PostID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PostID"));

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PostDate")
                        .HasColumnType("datetime2");

                    b.HasKey("PostID");

                    b.ToTable("Posts");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Post");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("SocialNetwork.Domain.Entities.PostHashtag", b =>
                {
                    b.Property<int>("PostHashtagID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PostHashtagID"));

                    b.Property<int>("HashtagID")
                        .HasColumnType("int");

                    b.Property<int>("PostID")
                        .HasColumnType("int");

                    b.HasKey("PostHashtagID");

                    b.HasIndex("HashtagID");

                    b.HasIndex("PostID");

                    b.ToTable("PostHashtags");
                });

            modelBuilder.Entity("SocialNetwork.Domain.Entities.Profile", b =>
                {
                    b.Property<string>("ProfileId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Bio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FristName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PicturePath")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProfileId");

                    b.ToTable("Profiles");
                });

            modelBuilder.Entity("SocialNetwork.Domain.Entities.Reaction", b =>
                {
                    b.Property<int>("ReactionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReactionID"));

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfileID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("ReactionDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("ReactionID");

                    b.HasIndex("ProfileID");

                    b.ToTable("Reactions");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Reaction");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("SocialNetwork.Domain.Entities.CommentMedia", b =>
                {
                    b.HasBaseType("SocialNetwork.Domain.Entities.Media");

                    b.Property<int>("CommentId")
                        .HasColumnType("int");

                    b.HasIndex("CommentId");

                    b.HasDiscriminator().HasValue("CommentMedia");
                });

            modelBuilder.Entity("SocialNetwork.Domain.Entities.MessageMedia", b =>
                {
                    b.HasBaseType("SocialNetwork.Domain.Entities.Media");

                    b.Property<int>("MessageId")
                        .HasColumnType("int");

                    b.HasIndex("MessageId");

                    b.HasDiscriminator().HasValue("MessageMedia");
                });

            modelBuilder.Entity("SocialNetwork.Domain.Entities.PostMedia", b =>
                {
                    b.HasBaseType("SocialNetwork.Domain.Entities.Media");

                    b.Property<int>("PostID")
                        .HasColumnType("int");

                    b.HasIndex("PostID");

                    b.HasDiscriminator().HasValue("PostMedia");
                });

            modelBuilder.Entity("SocialNetwork.Domain.Entities.GroupPost", b =>
                {
                    b.HasBaseType("SocialNetwork.Domain.Entities.Post");

                    b.Property<int>("GroupID")
                        .HasColumnType("int");

                    b.Property<string>("ProfileID")
                        .HasColumnType("nvarchar(450)");

                    b.HasIndex("GroupID");

                    b.HasIndex("ProfileID");

                    b.HasDiscriminator().HasValue("GroupPost");
                });

            modelBuilder.Entity("SocialNetwork.Domain.Entities.PagePost", b =>
                {
                    b.HasBaseType("SocialNetwork.Domain.Entities.Post");

                    b.Property<int>("PageID")
                        .HasColumnType("int");

                    b.HasIndex("PageID");

                    b.HasDiscriminator().HasValue("PagePost");
                });

            modelBuilder.Entity("SocialNetwork.Domain.Entities.ProfilePost", b =>
                {
                    b.HasBaseType("SocialNetwork.Domain.Entities.Post");

                    b.Property<string>("ProfileID")
                        .HasColumnType("nvarchar(450)");

                    b.HasIndex("ProfileID");

                    b.ToTable("Posts", t =>
                        {
                            t.Property("ProfileID")
                                .HasColumnName("ProfilePost_ProfileID");
                        });

                    b.HasDiscriminator().HasValue("ProfilePost");
                });

            modelBuilder.Entity("SocialNetwork.Domain.Entities.CommentReaction", b =>
                {
                    b.HasBaseType("SocialNetwork.Domain.Entities.Reaction");

                    b.Property<int>("CommentId")
                        .HasColumnType("int");

                    b.HasIndex("CommentId");

                    b.HasDiscriminator().HasValue("CommentReaction");
                });

            modelBuilder.Entity("SocialNetwork.Domain.Entities.MessageReaction", b =>
                {
                    b.HasBaseType("SocialNetwork.Domain.Entities.Reaction");

                    b.Property<int>("MessageId")
                        .HasColumnType("int");

                    b.HasIndex("MessageId");

                    b.HasDiscriminator().HasValue("MessageReaction");
                });

            modelBuilder.Entity("SocialNetwork.Domain.Entities.PostReaction", b =>
                {
                    b.HasBaseType("SocialNetwork.Domain.Entities.Reaction");

                    b.Property<int>("PostID")
                        .HasColumnType("int");

                    b.HasIndex("PostID");

                    b.HasDiscriminator().HasValue("PostReaction");
                });

            modelBuilder.Entity("SocialNetwork.Domain.Entities.ChatParticipant", b =>
                {
                    b.HasOne("SocialNetwork.Domain.Entities.Chat", "Chat")
                        .WithMany("Participants")
                        .HasForeignKey("ChatID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SocialNetwork.Domain.Entities.Profile", "Profile")
                        .WithMany("ChatParticipants")
                        .HasForeignKey("ProfileID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Chat");

                    b.Navigation("Profile");
                });

            modelBuilder.Entity("SocialNetwork.Domain.Entities.Comment", b =>
                {
                    b.HasOne("SocialNetwork.Domain.Entities.Post", "Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SocialNetwork.Domain.Entities.Profile", "Profile")
                        .WithMany("Comments")
                        .HasForeignKey("ProfileID");

                    b.Navigation("Post");

                    b.Navigation("Profile");
                });

            modelBuilder.Entity("SocialNetwork.Domain.Entities.Friend", b =>
                {
                    b.HasOne("SocialNetwork.Domain.Entities.Profile", "FriendProfile")
                        .WithMany()
                        .HasForeignKey("FriendProfileID");

                    b.HasOne("SocialNetwork.Domain.Entities.Profile", "Profile")
                        .WithMany()
                        .HasForeignKey("ProfileID");

                    b.Navigation("FriendProfile");

                    b.Navigation("Profile");
                });

            modelBuilder.Entity("SocialNetwork.Domain.Entities.FriendRequest", b =>
                {
                    b.HasOne("SocialNetwork.Domain.Entities.Profile", "ReceiverProfile")
                        .WithMany("FriendRequestsReceived")
                        .HasForeignKey("ReceiverProfileID")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("SocialNetwork.Domain.Entities.Profile", "SenderProfile")
                        .WithMany("FriendRequestsSend")
                        .HasForeignKey("SenderProfileID")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("ReceiverProfile");

                    b.Navigation("SenderProfile");
                });

            modelBuilder.Entity("SocialNetwork.Domain.Entities.Group", b =>
                {
                    b.HasOne("SocialNetwork.Domain.Entities.Profile", "CreatorProfile")
                        .WithMany("GroupsCreated")
                        .HasForeignKey("CreatorProfileID");

                    b.Navigation("CreatorProfile");
                });

            modelBuilder.Entity("SocialNetwork.Domain.Entities.GroupInvitation", b =>
                {
                    b.HasOne("SocialNetwork.Domain.Entities.Group", "Group")
                        .WithMany("GroupInvitations")
                        .HasForeignKey("GroupID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SocialNetwork.Domain.Entities.Profile", "InvitedByProfile")
                        .WithMany("ReceivedGroupInvitations")
                        .HasForeignKey("InvitedByProfileID")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("SocialNetwork.Domain.Entities.Profile", "InvitedProfile")
                        .WithMany("SentGroupInvitations")
                        .HasForeignKey("InvitedProfileID")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Group");

                    b.Navigation("InvitedByProfile");

                    b.Navigation("InvitedProfile");
                });

            modelBuilder.Entity("SocialNetwork.Domain.Entities.GroupMember", b =>
                {
                    b.HasOne("SocialNetwork.Domain.Entities.Group", "Group")
                        .WithMany("GroupMembers")
                        .HasForeignKey("GroupID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SocialNetwork.Domain.Entities.Profile", "Profile")
                        .WithMany("GroupMemberships")
                        .HasForeignKey("ProfileID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Group");

                    b.Navigation("Profile");
                });

            modelBuilder.Entity("SocialNetwork.Domain.Entities.Media", b =>
                {
                    b.HasOne("SocialNetwork.Domain.Entities.Profile", "Profile")
                        .WithMany()
                        .HasForeignKey("ProfileId");

                    b.Navigation("Profile");
                });

            modelBuilder.Entity("SocialNetwork.Domain.Entities.Message", b =>
                {
                    b.HasOne("SocialNetwork.Domain.Entities.Chat", "Chat")
                        .WithMany("Messages")
                        .HasForeignKey("ChatID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SocialNetwork.Domain.Entities.Profile", "SenderProfile")
                        .WithMany("Messages")
                        .HasForeignKey("SenderProfileID");

                    b.Navigation("Chat");

                    b.Navigation("SenderProfile");
                });

            modelBuilder.Entity("SocialNetwork.Domain.Entities.Notification", b =>
                {
                    b.HasOne("SocialNetwork.Domain.Entities.Profile", "Profile")
                        .WithMany("Notifications")
                        .HasForeignKey("ProfileID");

                    b.Navigation("Profile");
                });

            modelBuilder.Entity("SocialNetwork.Domain.Entities.Page", b =>
                {
                    b.HasOne("SocialNetwork.Domain.Entities.Profile", "CreatorProfile")
                        .WithMany("PagesCreated")
                        .HasForeignKey("CreatorProfileID");

                    b.Navigation("CreatorProfile");
                });

            modelBuilder.Entity("SocialNetwork.Domain.Entities.PageFollower", b =>
                {
                    b.HasOne("SocialNetwork.Domain.Entities.Page", "Page")
                        .WithMany("PageFollowers")
                        .HasForeignKey("PageID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SocialNetwork.Domain.Entities.Profile", "Profile")
                        .WithMany("PageFollowers")
                        .HasForeignKey("ProfileID");

                    b.Navigation("Page");

                    b.Navigation("Profile");
                });

            modelBuilder.Entity("SocialNetwork.Domain.Entities.PostHashtag", b =>
                {
                    b.HasOne("SocialNetwork.Domain.Entities.Hashtag", "Hashtag")
                        .WithMany("PostHashtags")
                        .HasForeignKey("HashtagID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SocialNetwork.Domain.Entities.Post", "Post")
                        .WithMany("PostHashtags")
                        .HasForeignKey("PostID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hashtag");

                    b.Navigation("Post");
                });

            modelBuilder.Entity("SocialNetwork.Domain.Entities.Reaction", b =>
                {
                    b.HasOne("SocialNetwork.Domain.Entities.Profile", "Profile")
                        .WithMany()
                        .HasForeignKey("ProfileID");

                    b.Navigation("Profile");
                });

            modelBuilder.Entity("SocialNetwork.Domain.Entities.CommentMedia", b =>
                {
                    b.HasOne("SocialNetwork.Domain.Entities.Comment", "Comment")
                        .WithMany("Medias")
                        .HasForeignKey("CommentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Comment");
                });

            modelBuilder.Entity("SocialNetwork.Domain.Entities.MessageMedia", b =>
                {
                    b.HasOne("SocialNetwork.Domain.Entities.Message", "Message")
                        .WithMany("Medias")
                        .HasForeignKey("MessageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Message");
                });

            modelBuilder.Entity("SocialNetwork.Domain.Entities.PostMedia", b =>
                {
                    b.HasOne("SocialNetwork.Domain.Entities.Post", "Post")
                        .WithMany("Medias")
                        .HasForeignKey("PostID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Post");
                });

            modelBuilder.Entity("SocialNetwork.Domain.Entities.GroupPost", b =>
                {
                    b.HasOne("SocialNetwork.Domain.Entities.Group", "Group")
                        .WithMany("GroupPosts")
                        .HasForeignKey("GroupID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SocialNetwork.Domain.Entities.Profile", "Profile")
                        .WithMany()
                        .HasForeignKey("ProfileID");

                    b.Navigation("Group");

                    b.Navigation("Profile");
                });

            modelBuilder.Entity("SocialNetwork.Domain.Entities.PagePost", b =>
                {
                    b.HasOne("SocialNetwork.Domain.Entities.Page", "Page")
                        .WithMany("PagePosts")
                        .HasForeignKey("PageID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Page");
                });

            modelBuilder.Entity("SocialNetwork.Domain.Entities.ProfilePost", b =>
                {
                    b.HasOne("SocialNetwork.Domain.Entities.Profile", "Profile")
                        .WithMany("ProfilePosts")
                        .HasForeignKey("ProfileID");

                    b.Navigation("Profile");
                });

            modelBuilder.Entity("SocialNetwork.Domain.Entities.CommentReaction", b =>
                {
                    b.HasOne("SocialNetwork.Domain.Entities.Comment", "Comment")
                        .WithMany("CommentReactions")
                        .HasForeignKey("CommentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Comment");
                });

            modelBuilder.Entity("SocialNetwork.Domain.Entities.MessageReaction", b =>
                {
                    b.HasOne("SocialNetwork.Domain.Entities.Message", "Message")
                        .WithMany("MessageReactions")
                        .HasForeignKey("MessageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Message");
                });

            modelBuilder.Entity("SocialNetwork.Domain.Entities.PostReaction", b =>
                {
                    b.HasOne("SocialNetwork.Domain.Entities.Post", "Post")
                        .WithMany("PostReactions")
                        .HasForeignKey("PostID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Post");
                });

            modelBuilder.Entity("SocialNetwork.Domain.Entities.Chat", b =>
                {
                    b.Navigation("Messages");

                    b.Navigation("Participants");
                });

            modelBuilder.Entity("SocialNetwork.Domain.Entities.Comment", b =>
                {
                    b.Navigation("CommentReactions");

                    b.Navigation("Medias");
                });

            modelBuilder.Entity("SocialNetwork.Domain.Entities.Group", b =>
                {
                    b.Navigation("GroupInvitations");

                    b.Navigation("GroupMembers");

                    b.Navigation("GroupPosts");
                });

            modelBuilder.Entity("SocialNetwork.Domain.Entities.Hashtag", b =>
                {
                    b.Navigation("PostHashtags");
                });

            modelBuilder.Entity("SocialNetwork.Domain.Entities.Message", b =>
                {
                    b.Navigation("Medias");

                    b.Navigation("MessageReactions");
                });

            modelBuilder.Entity("SocialNetwork.Domain.Entities.Page", b =>
                {
                    b.Navigation("PageFollowers");

                    b.Navigation("PagePosts");
                });

            modelBuilder.Entity("SocialNetwork.Domain.Entities.Post", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Medias");

                    b.Navigation("PostHashtags");

                    b.Navigation("PostReactions");
                });

            modelBuilder.Entity("SocialNetwork.Domain.Entities.Profile", b =>
                {
                    b.Navigation("ChatParticipants");

                    b.Navigation("Comments");

                    b.Navigation("FriendRequestsReceived");

                    b.Navigation("FriendRequestsSend");

                    b.Navigation("GroupMemberships");

                    b.Navigation("GroupsCreated");

                    b.Navigation("Messages");

                    b.Navigation("Notifications");

                    b.Navigation("PageFollowers");

                    b.Navigation("PagesCreated");

                    b.Navigation("ProfilePosts");

                    b.Navigation("ReceivedGroupInvitations");

                    b.Navigation("SentGroupInvitations");
                });
#pragma warning restore 612, 618
        }
    }
}
