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
    public class RejectFriendRequestValidator : AbstractValidator<RejectFriendRequestCommand>
    {
        public RejectFriendRequestValidator(IGenericService<FriendRequest> friendRequestService)
        {
            RuleFor(x => x.ReceiverProfileID)
                .MustAsync(async (command, receiverProfileID, _) =>
                {
                    var friendRequest = await friendRequestService.GetByIdAsync(command.FriendRequestID);
                    return friendRequest is not null && friendRequest.ReceiverProfileID == receiverProfileID && friendRequest.FriendRequestStatus == FriendRequestStatus.Pending;
                }
                ).WithMessage("FriendRequest entity is not found or FriendRequestStatus is not pending");
        }
    }
}
