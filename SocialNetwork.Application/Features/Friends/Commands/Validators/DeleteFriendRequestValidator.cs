using FluentValidation;
using SocialNetwork.Application.Features.Friends.Commands.Models;
using SocialNetwork.Application.Services.Contract;
using SocialNetwork.Domain.Entities;
using SocialNetwork.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Application.Features.Friends.Commands.Validators
{
    public class DeleteFriendRequestValidator : AbstractValidator<DeleteFriendRequestCommand>
    {
        public DeleteFriendRequestValidator(IGenericService<FriendRequest> friendRequestService)
        {
            RuleFor(x => x.SenderProfileID)
                .MustAsync(async (command, senderProfileID, _) =>
                {
                    var friendRequest = await friendRequestService.GetByIdAsync(command.FriendRequestID);
                    return friendRequest is not null && friendRequest.SenderProfileID == senderProfileID && friendRequest.FriendRequestStatus == FriendRequestStatus.Pending;
                //(await friendRequestService.GetByIdAsync(command.FriendRequestID))?.SenderProfileID == senderProfileID
                }
                ).WithMessage("FriendRequest entity is not found or FriendRequestStatus is not pending");
                //.MustAsync()
        }
    }
}
