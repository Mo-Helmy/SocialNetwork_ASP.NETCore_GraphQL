using MediatR;
using SocialNetwork.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SocialNetwork.Application.Features.Friends.Commands.Models
{
    public class SendFriendRequestCommand : IRequest<BaseResponse<string>>
    {
        [JsonIgnore]
        public string? SenderProfileID { get; set; }
        public string ReceiverProfileID { get; set; }
    }
}
