#nullable disable
using Microsoft.AspNetCore.Identity;
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
    public class User : IdentityUser
    {
        public DateTime RegistrationDate { get; set; }
        public DateTime LastLoginDate { get; set; }

        // Navigation properties for relationships
        public Profile Profile { get; set; }
        public ICollection<Group> GroupsCreated { get; set; }
        public ICollection<GroupMember> GroupMemberships { get; set; }
        public ICollection<GroupInvitation> ReceivedGroupInvitations { get; set; }
        public ICollection<GroupInvitation> SentGroupInvitations { get; set; }
        public ICollection<Page> PagesCreated { get; set; }
        public ICollection<PageFollower> PageFollowers { get; set; }
        public ICollection<Post> Posts { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Friendship> FriendshipsSend { get; set; }
        public ICollection<Friendship> FriendshipsReceived { get; set; }
        public ICollection<User> Friends { get; set; }
        public ICollection<Chat> Chats { get; set; }
        public ICollection<ChatParticipant> ChatParticipants { get; set; }
        public ICollection<Message> Messages { get; set; }
        public ICollection<Notification> Notifications { get; set; }
    }

    public class Profile
    {
        public int Id { get; set; }
        public string FristName { get; set; }
        public string LastName { get; set; }
        public string? Bio {  get; set; }
        public Gender Gender { get; set; }
        public string? PicturePath { get; set; }
        public DateTime? BirthDate { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }
    }

    public class Friendship
    {
        public int FriendshipID { get; set; }
        public string SenderUserID { get; set; }
        public string ReceiverUserID { get; set; }
        public FriendshipStatus FriendshipStatus { get; set; }

        // Navigation properties
        public User SenderUser { get; set; }
        public User ReceiverUser { get; set; }
    }
    public class Group
    {
        public int GroupID { get; set; }
        public string GroupName { get; set; }
        public string? GroupDescription { get; set; }
        public string CreatorUserID { get; set; }
        public GroupStatus GroupStatus { get; set; }
        public DateTime CreationDate { get; set; }
        // Navigation properties
        public User CreatorUser { get; set; }
        public ICollection<GroupMember> GroupMembers { get; set; }
        public ICollection<GroupInvitation> GroupInvitations { get; set; }
        public ICollection<GroupPost> GroupPosts { get; set; }
    }
    public class GroupMember
    {
        public int GroupMemberID { get; set; }
        public int GroupID { get; set; }
        public string UserID { get; set; }
        public GroupMemberRole Role { get; set; }
        public DateTime JoinDate { get; set; }
        // Navigation properties
        public Group Group { get; set; }
        public User User { get; set; }
    }
    public class GroupInvitation
    {
        public int GroupInvitationID { get; set; }
        public int GroupID { get; set; }
        public string InvitedUserID { get; set; }
        public string InvitedByUserID { get; set; }
        public DateTime InvitationDate { get; set; }
        public InvitationStatus Status { get; set; } // Enum for Pending, Accepted, Declined

        // Navigation properties
        public Group Group { get; set; }
        public User InvitedUser { get; set; }
        public User InvitedByUser { get; set; }
    }

    public class Page
    {
        public int PageID { get; set; }
        public string PageName { get; set; }
        public string? PageDescription {  get; set; }
        public string CreatorUserID { get; set; }
        public DateTime CreationDate { get; set; }

        // Navigation properties
        public User CreatorUser { get; set; }
        public ICollection<PageFollower> PageFollowers { get; set; }
        public ICollection<PagePost> PagePosts { get; set; }
    }
    public class PageFollower
    {
        public int PageFollowerID { get; set; }
        public int PageID { get; set; }
        public string? UserID { get; set; }
        public PageFollowerRole Role { get; set; }

        // Navigation properties
        public Page Page { get; set; }
        public User User { get; set; }
    }
    public class Post
    {
        public int PostID { get; set; }
        public string Content { get; set; }
        public string UserID { get; set; }
        public DateTime PostDate { get; set; }

        // Navigation properties
        public User User { get; set; }
        public ICollection<PostMedia> Medias { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<PostReaction> PostReactions { get; set; }
        public ICollection<PostHashtag> PostHashtags { get; set; }
    }

    public class GroupPost : Post
    {
        public int GroupID { get; set; }
        public Group Group { get; set; }
    }

    public class PagePost : Post
    {
        public int PageID { get; set; }
        public Page Page { get; set; }
    }

    public class Media
    {
        public int MediaID { get; set; }
        public string UserId { get; set; }
        public MediaType Type { get; set; } // MediaType is an enum
        public string Path { get; set; } // URL or path to the media
        public DateTime UploadDate { get; set; }

        // Navigation properties
        public User User { get; set; }
    }

    public class PostMedia : Media
    {
        public int PostID { get; set; }
        public Post Post { get; set; }
    }

    public class CommentMedia : Media
    {
        public int CommentId { get; set; }
        public Comment Comment { get; set; }
    }

    public class MessageMedia : Media
    {
        public int MessageId { get; set; }
        public Message Message { get; set; }

    }

    public class Reaction
    {
        public int ReactionID { get; set; }
        public string? UserID { get; set; }
        public ReactionType Type { get; set; } 
        public DateTime ReactionDate { get; set; }

        // Navigation properties
        public User User { get; set; }
    }

    public class PostReaction : Reaction
    {
        public int PostID { get; set; }
        public Post Post { get; set; }
    }
    public class CommentReaction : Reaction
    {
        public int CommentId { get; set; }
        public Comment Comment { get; set; }
    }
    public class MessageReaction : Reaction
    {
        public int MessageId { get; set; }
        public Message Message { get; set; }
    }

    public class Comment
    {
        public int CommentID { get; set; }
        public int PostID { get; set; }
        public string? UserID { get; set; }
        public string CommentText { get; set; }
        public DateTime CommentDate { get; set; }

        // Navigation properties
        public Post Post { get; set; }
        public User User { get; set; }
        public ICollection<CommentMedia> Medias { get; set; }
        public ICollection<CommentReaction> CommentReactions { get; set; }
    }

    public class Chat
    {
        public int ChatID { get; set; }
        public DateTime StartDate { get; set; }

        // Navigation properties
        public ICollection<ChatParticipant> Participants { get; set; }
        public ICollection<Message> Messages { get; set; }
    }

    public class ChatParticipant
    {
        public string UserID { get; set; }
        public int ChatID { get; set; }

        // Navigation properties
        public User User { get; set; }
        public Chat Chat { get; set; }
    }

    public class Message
    {
        public int MessageID { get; set; }
        public int ChatID { get; set; }
        public string SenderUserID { get; set; }
        public string MessageText { get; set; }
        public DateTime SendDate { get; set; }

        // Navigation properties
        public Chat Chat { get; set; }
        public User SenderUser { get; set; }
        public ICollection<MessageMedia> Medias { get; set; }
        public ICollection<MessageReaction> MessageReactions { get; set; }
    }

    public class Notification
    {
        public int NotificationID { get; set; }
        public string UserID { get; set; }
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
