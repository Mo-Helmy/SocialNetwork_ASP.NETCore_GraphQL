using SocialNetwork.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Application.Features.Chats.Commands.Responses
{
    public class MessageReactionResponse
    {
        public int ReactionID { get; set; }
        public string? ProfileID { get; set; }
        public ReactionType Type { get; set; }
        public int MessageId { get; set; }
    }
}
