using MediatR;
using SocialNetwork.Application.Responses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SocialNetwork.Application.Features.Friends.Commands.Models
{
    public class AcceptFriendRequestCommand : IRequest<BaseResponse<string>>
    {
        [Required]
        public int FriendRequestID { get; set; }

        [JsonIgnore]
        public string? ReceiverProfileID { get; set; }
        
        //[Required]
        //public string SenderProfileID { get; set; }

    }
}
