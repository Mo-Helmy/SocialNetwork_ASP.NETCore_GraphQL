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
    public class SendNewMessageCommand : IRequest<SendNewMessageResponse>
    {
        [JsonIgnore]
        public string? SenderProfileId { get; set; }

        [Required]
        public int ChatID { get; set; }

        public string? MessageText { get; set; }

        public IEnumerable<SendNewMediaCommand>? Medias { get; set; }

        //public MediaType? MediaType { get; set; }

        //public string? MediaPath { get; set; }
    }
}
