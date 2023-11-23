﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SocialNetwork.Infrastructure.Data;

#nullable disable

namespace SocialNetwork.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("SocialNetwork.Domain.Entities.Chat", b =>
                {
                    b.Property<int>("ChatID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ChatID"));

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ChatID");

                    b.HasIndex("UserId");

                    b.ToTable("Chats");
                });

            modelBuilder.Entity("SocialNetwork.Domain.Entities.ChatParticipant", b =>
                {
                    b.Property<string>("UserID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("ChatID")
                        .HasColumnType("int");

                    b.HasKey("UserID", "ChatID");

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

                    b.Property<string>("UserID")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("CommentID");

                    b.HasIndex("PostID");

                    b.HasIndex("UserID");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("SocialNetwork.Domain.Entities.Friendship", b =>
                {
                    b.Property<int>("FriendshipID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FriendshipID"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("UserID1")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserID2")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("FriendshipID");

                    b.HasIndex("UserID1");

                    b.HasIndex("UserID2");

                    b.ToTable("Friendships");
                });

            modelBuilder.Entity("SocialNetwork.Domain.Entities.Group", b =>
                {
                    b.Property<int>("GroupID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GroupID"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatorUserID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("GroupDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GroupName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GroupStatus")
                        .HasColumnType("int");

                    b.HasKey("GroupID");

                    b.HasIndex("CreatorUserID");

                    b.ToTable("Groups");
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

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserID")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("GroupMemberID");

                    b.HasIndex("GroupID");

                    b.HasIndex("UserID");

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

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MessageID")
                        .HasColumnType("int");

                    b.Property<int?>("PostID")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<DateTime>("UploadDate")
                        .HasColumnType("datetime2");

                    b.HasKey("MediaID");

                    b.HasIndex("MessageID");

                    b.HasIndex("PostID");

                    b.ToTable("Medias");
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

                    b.Property<string>("SenderUserID")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("MessageID");

                    b.HasIndex("ChatID");

                    b.HasIndex("SenderUserID");

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

                    b.Property<string>("UserID")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("NotificationID");

                    b.HasIndex("UserID");

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

                    b.Property<string>("CreatorUserID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PageName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PageID");

                    b.HasIndex("CreatorUserID");

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

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserID")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("PageFollowerID");

                    b.HasIndex("PageID");

                    b.HasIndex("UserID");

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

                    b.Property<int?>("GroupID")
                        .HasColumnType("int");

                    b.Property<int?>("PageID")
                        .HasColumnType("int");

                    b.Property<DateTime>("PostDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("RelatedGroupID")
                        .HasColumnType("int");

                    b.Property<int?>("RelatedPageID")
                        .HasColumnType("int");

                    b.Property<string>("UserID")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("PostID");

                    b.HasIndex("GroupID");

                    b.HasIndex("PageID");

                    b.HasIndex("UserID");

                    b.ToTable("Posts");
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

            modelBuilder.Entity("SocialNetwork.Domain.Entities.Reaction", b =>
                {
                    b.Property<int>("ReactionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReactionID"));

                    b.Property<int>("PostID")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReactionDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<string>("UserID")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ReactionID");

                    b.HasIndex("PostID");

                    b.HasIndex("UserID");

                    b.ToTable("Reactions");
                });

            modelBuilder.Entity("SocialNetwork.Domain.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastLoginDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("ProfileId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.HasIndex("ProfileId");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("User");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("SocialNetwork.Domain.Entities.Profile", b =>
                {
                    b.HasBaseType("SocialNetwork.Domain.Entities.User");

                    b.Property<string>("Bio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FristName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Profile");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("SocialNetwork.Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("SocialNetwork.Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SocialNetwork.Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("SocialNetwork.Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SocialNetwork.Domain.Entities.Chat", b =>
                {
                    b.HasOne("SocialNetwork.Domain.Entities.User", null)
                        .WithMany("Chats")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("SocialNetwork.Domain.Entities.ChatParticipant", b =>
                {
                    b.HasOne("SocialNetwork.Domain.Entities.Chat", "Chat")
                        .WithMany("Participants")
                        .HasForeignKey("ChatID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SocialNetwork.Domain.Entities.User", "User")
                        .WithMany("ChatParticipants")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Chat");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SocialNetwork.Domain.Entities.Comment", b =>
                {
                    b.HasOne("SocialNetwork.Domain.Entities.Post", "Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SocialNetwork.Domain.Entities.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserID");

                    b.Navigation("Post");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SocialNetwork.Domain.Entities.Friendship", b =>
                {
                    b.HasOne("SocialNetwork.Domain.Entities.User", "User1")
                        .WithMany("FriendshipsInitiated")
                        .HasForeignKey("UserID1")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("SocialNetwork.Domain.Entities.User", "User2")
                        .WithMany("FriendshipsReceived")
                        .HasForeignKey("UserID2")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("User1");

                    b.Navigation("User2");
                });

            modelBuilder.Entity("SocialNetwork.Domain.Entities.Group", b =>
                {
                    b.HasOne("SocialNetwork.Domain.Entities.User", "CreatorUser")
                        .WithMany("GroupsCreated")
                        .HasForeignKey("CreatorUserID");

                    b.Navigation("CreatorUser");
                });

            modelBuilder.Entity("SocialNetwork.Domain.Entities.GroupMember", b =>
                {
                    b.HasOne("SocialNetwork.Domain.Entities.Group", "Group")
                        .WithMany("GroupMembers")
                        .HasForeignKey("GroupID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SocialNetwork.Domain.Entities.User", "User")
                        .WithMany("GroupMemberships")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Group");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SocialNetwork.Domain.Entities.Media", b =>
                {
                    b.HasOne("SocialNetwork.Domain.Entities.Message", "Message")
                        .WithMany("Medias")
                        .HasForeignKey("MessageID");

                    b.HasOne("SocialNetwork.Domain.Entities.Post", "Post")
                        .WithMany("Medias")
                        .HasForeignKey("PostID");

                    b.Navigation("Message");

                    b.Navigation("Post");
                });

            modelBuilder.Entity("SocialNetwork.Domain.Entities.Message", b =>
                {
                    b.HasOne("SocialNetwork.Domain.Entities.Chat", "Chat")
                        .WithMany("Messages")
                        .HasForeignKey("ChatID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SocialNetwork.Domain.Entities.User", "SenderUser")
                        .WithMany("Messages")
                        .HasForeignKey("SenderUserID");

                    b.Navigation("Chat");

                    b.Navigation("SenderUser");
                });

            modelBuilder.Entity("SocialNetwork.Domain.Entities.Notification", b =>
                {
                    b.HasOne("SocialNetwork.Domain.Entities.User", "User")
                        .WithMany("Notifications")
                        .HasForeignKey("UserID");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SocialNetwork.Domain.Entities.Page", b =>
                {
                    b.HasOne("SocialNetwork.Domain.Entities.User", "CreatorUser")
                        .WithMany("PagesCreated")
                        .HasForeignKey("CreatorUserID");

                    b.Navigation("CreatorUser");
                });

            modelBuilder.Entity("SocialNetwork.Domain.Entities.PageFollower", b =>
                {
                    b.HasOne("SocialNetwork.Domain.Entities.Page", "Page")
                        .WithMany("PageFollowers")
                        .HasForeignKey("PageID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SocialNetwork.Domain.Entities.User", "User")
                        .WithMany("PageFollowers")
                        .HasForeignKey("UserID");

                    b.Navigation("Page");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SocialNetwork.Domain.Entities.Post", b =>
                {
                    b.HasOne("SocialNetwork.Domain.Entities.Group", "Group")
                        .WithMany("Posts")
                        .HasForeignKey("GroupID");

                    b.HasOne("SocialNetwork.Domain.Entities.Page", "Page")
                        .WithMany("Posts")
                        .HasForeignKey("PageID");

                    b.HasOne("SocialNetwork.Domain.Entities.User", "User")
                        .WithMany("Posts")
                        .HasForeignKey("UserID");

                    b.Navigation("Group");

                    b.Navigation("Page");

                    b.Navigation("User");
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
                    b.HasOne("SocialNetwork.Domain.Entities.Post", "Post")
                        .WithMany("Reactions")
                        .HasForeignKey("PostID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SocialNetwork.Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID");

                    b.Navigation("Post");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SocialNetwork.Domain.Entities.User", b =>
                {
                    b.HasOne("SocialNetwork.Domain.Entities.Profile", "Profile")
                        .WithMany()
                        .HasForeignKey("ProfileId");

                    b.Navigation("Profile");
                });

            modelBuilder.Entity("SocialNetwork.Domain.Entities.Chat", b =>
                {
                    b.Navigation("Messages");

                    b.Navigation("Participants");
                });

            modelBuilder.Entity("SocialNetwork.Domain.Entities.Group", b =>
                {
                    b.Navigation("GroupMembers");

                    b.Navigation("Posts");
                });

            modelBuilder.Entity("SocialNetwork.Domain.Entities.Hashtag", b =>
                {
                    b.Navigation("PostHashtags");
                });

            modelBuilder.Entity("SocialNetwork.Domain.Entities.Message", b =>
                {
                    b.Navigation("Medias");
                });

            modelBuilder.Entity("SocialNetwork.Domain.Entities.Page", b =>
                {
                    b.Navigation("PageFollowers");

                    b.Navigation("Posts");
                });

            modelBuilder.Entity("SocialNetwork.Domain.Entities.Post", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Medias");

                    b.Navigation("PostHashtags");

                    b.Navigation("Reactions");
                });

            modelBuilder.Entity("SocialNetwork.Domain.Entities.User", b =>
                {
                    b.Navigation("ChatParticipants");

                    b.Navigation("Chats");

                    b.Navigation("Comments");

                    b.Navigation("FriendshipsInitiated");

                    b.Navigation("FriendshipsReceived");

                    b.Navigation("GroupMemberships");

                    b.Navigation("GroupsCreated");

                    b.Navigation("Messages");

                    b.Navigation("Notifications");

                    b.Navigation("PageFollowers");

                    b.Navigation("PagesCreated");

                    b.Navigation("Posts");
                });
#pragma warning restore 612, 618
        }
    }
}
