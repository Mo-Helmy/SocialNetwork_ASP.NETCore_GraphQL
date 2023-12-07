using MediatR;
using SocialNetwork.Application.Features.Chats.Commands.Responses;
using SocialNetwork.Domain.Entities;
using SocialNetwork.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SocialNetwork.Application.Features.Chats.Commands.Models
{
    public class ReactToMessageCommand : IRequest<MessageReactionResponse>
    {
        [JsonIgnore]
        public string? ProfileID { get; set; }

        public int? ReactionID {  get; set; }

        [Required]
        public int MessageId { get; set; }

        public ReactionType Type { get; set; }

        public int ChatId { get; set; }

    }
}
