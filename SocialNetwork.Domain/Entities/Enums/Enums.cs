using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Domain.Entities.Enums
{
    public enum Gender
    {
        Male,
        Female
    }
    public enum ReactionType
    {
        Like,
        Dislike,
        Sad,
        Happy,
        Excited
    }

    public enum MediaType
    {
        Image,
        Video,
        Audio, // Additional media type suggestion
        Document // Another possible media type
    }

    public enum FriendshipStatus
    {
        Pending,
        Accept,
        Reject,
        Block
    }

    public enum PageFollowerRole
    {
        Admin,
        Moderator,
        Member,
    }

    public enum GroupMemberRole
    {
        Admin,
        Moderator,
        Member,
    }

    public enum GroupStatus
    {
        Public,
        Private,
        Secret
    }

    public enum InvitationStatus
    {
        Pending,
        Accepted,
        Declined
    }

}
