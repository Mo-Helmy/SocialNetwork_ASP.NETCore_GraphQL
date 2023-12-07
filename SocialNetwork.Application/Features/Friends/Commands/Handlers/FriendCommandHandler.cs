using MediatR;
using SocialNetwork.Application.Features.Friends.Commands.Models;
using SocialNetwork.Application.Responses;
using SocialNetwork.Application.Services.Contract;
using SocialNetwork.Domain.Entities;
using SocialNetwork.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Application.Features.Friends.Commands.Handlers
{
    public class FriendCommandHandler : IRequestHandler<SendFriendRequestCommand, BaseResponse<string>>,
                                        IRequestHandler<DeleteFriendRequestCommand, BaseResponse<string>>,
                                        IRequestHandler<AcceptFriendRequestCommand, BaseResponse<string>>,
                                        IRequestHandler<RejectFriendRequestCommand, BaseResponse<string>>
    {
        private readonly IFriendRequestService _friendRequestService;
        private readonly IFriendService _friendService;
        private readonly INotificationService _notificationService;
        private readonly IProfileService _profileService;

        public FriendCommandHandler(
            IFriendRequestService friendRequestService,
            IFriendService friendService, 
            INotificationService notificationService, 
            IProfileService profileService
            )
        {
            this._friendRequestService = friendRequestService;
            this._friendService = friendService;
            this._notificationService = notificationService;
            this._profileService = profileService;
        }


        public async Task<BaseResponse<string>> Handle(SendFriendRequestCommand request, CancellationToken cancellationToken)
        {
            await _friendRequestService.CreateAsync(new FriendRequest()
            {
                SenderProfileID = request.SenderProfileID,
                ReceiverProfileID = request.ReceiverProfileID,
                FriendRequestStatus = FriendRequestStatus.Pending
            });


            return new BaseResponse<string> { StatusCode = System.Net.HttpStatusCode.OK, Message = "FriendRequest Created Successfully!", Succeeded = true };
        }

        public async Task<BaseResponse<string>> Handle(DeleteFriendRequestCommand request, CancellationToken cancellationToken)
        {
            //// Done in DeleteFriendRequestValidator Class
            //var friendRequestEntity = await _friendRequestService.GetByIdAsync(request.FriendRequestID) 
            //    ?? throw new KeyNotFoundException("FriendRequest id is not exist");

            //if (friendRequestEntity.SenderProfileID != request.SenderProfileID)
            //    throw new UnauthorizedAccessException("You are unauthorized to modify this entity");

            await _friendRequestService.DeleteAsync(request.FriendRequestID);

            return new BaseResponse<string> { StatusCode = System.Net.HttpStatusCode.OK, Message = "FriendRequest Deleted Successfully!", Succeeded = true };
        }

        public async Task<BaseResponse<string>> Handle(AcceptFriendRequestCommand request, CancellationToken cancellationToken)
        {
            await _friendService.AcceptFriendRequestAsync(request);

            return new BaseResponse<string> { StatusCode = System.Net.HttpStatusCode.OK, Message = "Friend Request Accepted Successfully!" };
        }

        public async Task<BaseResponse<string>> Handle(RejectFriendRequestCommand request, CancellationToken cancellationToken)
        {
            await _friendService.RejectFriendRequestAsync(request);

            return new BaseResponse<string> { StatusCode = System.Net.HttpStatusCode.OK, Message = "Friend Request Rejected Successfully!" };
        }
    }
}
