using SocialNetwork.Application.Dtos.MailDtos;
using SocialNetwork.Application.Features.Chats.Commands.Models;
using SocialNetwork.Application.Features.Friends.Commands.Models;
using SocialNetwork.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Application.Services.Contract
{
    public interface IFriendService : IGenericService<Friend>
    {
        Task<FriendRequest> AcceptFriendRequestAsync(AcceptFriendRequestCommand requestCommand);
        Task<FriendRequest> RejectFriendRequestAsync(RejectFriendRequestCommand requestCommand);
    }
}
