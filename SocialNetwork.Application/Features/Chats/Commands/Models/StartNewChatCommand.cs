using MediatR;
using SocialNetwork.Application.Features.Chats.Commands.Responses;
using SocialNetwork.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SocialNetwork.Application.Features.Chats.Commands.Models
{
    public class StartNewChatCommand : IRequest<StartNewChatResponse>
    {
        [JsonIgnore]
        public string? SenderProfileId { get; set; }
        public string recivererProfileId { get; set; }
        public string MessageText { get; set; }

    }
}
