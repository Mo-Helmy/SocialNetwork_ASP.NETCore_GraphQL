#nullable disable
using SocialNetwork.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SocialNetwork.Domain.Entities
{
    public class User
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; } // Consider using secure hash instead of plain text
        public string ProfileInformation { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime LastLoginDate { get; set; }
        // Navigation properties for relationships
        public ICollection<Group> GroupsCreated { get; set; }
        public ICollection<GroupMember> GroupMemberships { get; set; }
        public ICollection<Page> PagesCreated { get; set; }
        public ICollection<PageFollower> PageFollowers { get; set; }
        public ICollection<Post> Posts { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Friendship> Friendships { get; set; }
        public ICollection<Chat> Chats { get; set; }
        public ICollection<Message> Messages { get; set; }
        public ICollection<Notification> Notifications { get; set; }
    }
    public class Group
    {
        public int GroupID { get; set; }
        public string GroupName { get; set; }
        public int CreatorUserID { get; set; }
        public GroupStatus GroupStatus { get; set; }
        public DateTime CreationDate { get; set; }
        // Navigation properties
        public User CreatorUser { get; set; }
        public ICollection<GroupMember> GroupMembers { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
    public class GroupMember
    {
        public int GroupMemberID { get; set; }
        public int GroupID { get; set; }
        public int UserID { get; set; }
        public string Role { get; set; }
        public DateTime JoinDate { get; set; }
        // Navigation properties
        public Group Group { get; set; }
        public User User { get; set; }
    }
    public class Page
    {
        public int PageID { get; set; }
        public string PageName { get; set; }
        public int CreatorUserID { get; set; }
        public DateTime CreationDate { get; set; }

        // Navigation properties
        public User CreatorUser { get; set; }
        public ICollection<PageFollower> PageFollowers { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
    public class PageFollower
    {
        public int PageFollowerID { get; set; }
        public int PageID { get; set; }
        public int? UserID { get; set; }
        public string Role { get; set; }

        // Navigation properties
        public Page Page { get; set; }
        public User User { get; set; }
    }
    public class Post
    {
        public int PostID { get; set; }
        public string Content { get; set; }
        public int UserID { get; set; }
        public DateTime PostDate { get; set; }
        public int? RelatedGroupID { get; set; }
        public int? RelatedPageID { get; set; }

        // Navigation properties
        public User User { get; set; }
        public Group Group { get; set; }
        public Page Page { get; set; }
        public ICollection<Media> Media { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Reaction> Reactions { get; set; }
        public ICollection<PostHashtag> PostHashtags { get; set; }
    }
    public class Media
    {
        public int MediaID { get; set; }
        public int PostID { get; set; }
        public MediaType Type { get; set; } // MediaType is an enum
        public string Location { get; set; } // URL or path to the media
        public DateTime UploadDate { get; set; }

        // Navigation properties
        public Post Post { get; set; }
    }
    public class Reaction
    {
        public int ReactionID { get; set; }
        public int? UserID { get; set; }
        public int PostID { get; set; }
        public ReactionType Type { get; set; } // ReactionType is an enum
        public DateTime ReactionDate { get; set; }

        // Navigation properties
        public User User { get; set; }
        public Post Post { get; set; }
    }

    public class Comment
    {
        public int CommentID { get; set; }
        public int PostID { get; set; }
        public int? UserID { get; set; }
        public string CommentText { get; set; }
        public DateTime CommentDate { get; set; }
        // Navigation properties
        public Post Post { get; set; }
        public User User { get; set; }
    }
    public class Friendship
    {
        public int FriendshipID { get; set; }
        public int User1ID { get; set; }
        public int User2ID { get; set; }
        public FriendshipStatus FriendshipStatus { get; set; }
        // Navigation properties
        public User User1 { get; set; }
        public User User2 { get; set; }
    }
    public class Chat
    {
        public int ChatID { get; set; }
        public int User1ID { get; set; }
        public int User2ID { get; set; }
        public DateTime StartDate { get; set; }

        // Navigation properties
        public User User1 { get; set; }
        public User User2 { get; set; }
        public ICollection<Message> Messages { get; set; }
    }

    public class Message
    {
        public int MessageID { get; set; }
        public int ChatID { get; set; }
        public int SenderUserID { get; set; }
        public string MessageText { get; set; }
        public DateTime SendDate { get; set; }

        // Navigation properties
        public Chat Chat { get; set; }
        public User SenderUser { get; set; }
    }
    public class Notification
    {
        public int NotificationID { get; set; }
        public int UserID { get; set; }
        public string NotificationText { get; set; }
        public DateTime NotificationDate { get; set; }
        public bool IsRead { get; set; }

        // Navigation properties
        public User User { get; set; }
    }
    public class Hashtag
    {
        public int HashtagID { get; set; }
        public string HashtagText { get; set; }
        // Navigation property
        public ICollection<PostHashtag> PostHashtags { get; set; }
    }
    public class PostHashtag
    {
        public int PostHashtagID { get; set; }
        public int PostID { get; set; }
        public int HashtagID { get; set; }
        // Navigation properties
        public Post Post { get; set; }
        public Hashtag Hashtag { get; set; }
    }


}
