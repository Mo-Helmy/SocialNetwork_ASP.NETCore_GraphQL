using MediatR;
using Microsoft.AspNetCore.SignalR;
using SocialNetwork.Application.Features.Friends.Commands.Models;
using SocialNetwork.Application.Hubs;
using SocialNetwork.Application.Services.Contract;
using SocialNetwork.Domain.Entities;
using SocialNetwork.Domain.Entities.Enums;
using SocialNetwork.Infrastructure.Specifications;
using SocialNetwork.Infrastructure.UnitOfWorks.Contract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio.TwiML.Voice;

namespace SocialNetwork.Application.Services
{
    public class FriendService : GenericService<Friend>, IFriendService
    {
        private readonly INotificationService _notificationService;
        private readonly IHubContext<NotificationHub> _hubContext;

        public FriendService(IUnitOfWork unitOfWork, INotificationService notificationService, IHubContext<NotificationHub> hubContext) : base(unitOfWork)
        {
            this._notificationService = notificationService;
            this._hubContext = hubContext;
        }

        public async Task<FriendRequest> AcceptFriendRequestAsync(AcceptFriendRequestCommand requestCommand)
        {
            var friendRequest = await _unitOfWork
                .GetRepository<FriendRequest>()
                .GetByIdWithSpecAsync(new BaseSpecification<FriendRequest>(
                    x => x.FriendRequestID == requestCommand.FriendRequestID &&
                    x.ReceiverProfileID == requestCommand.ReceiverProfileID
                    )
                {
                    Includes = new() { x => x.SenderProfile, x => x.ReceiverProfile }
                });

            if (friendRequest == null)
                throw new ValidationException("Friend Request not found!");
            if (friendRequest.FriendRequestStatus is not FriendRequestStatus.Pending)
                throw new ValidationException("Friend Request Status should be pending to change it!");

            friendRequest.FriendRequestStatus = FriendRequestStatus.Accept;

            await _unitOfWork.GetRepository<FriendRequest>().UpdateAsync(friendRequest);

            // add friend entity
            await _unitOfWork.GetRepository<Friend>().CreateAsync(new Friend()
            {
                ProfileID = friendRequest.SenderProfileID,
                FriendProfileID = friendRequest.ReceiverProfileID,
                StartDate = DateTime.Now,
            });
            await _unitOfWork.GetRepository<Friend>().CreateAsync(new Friend()
            {
                ProfileID = friendRequest.ReceiverProfileID,
                FriendProfileID = friendRequest.SenderProfileID,
                StartDate = DateTime.Now,
            });

            await _unitOfWork.Complete();

            // send notification && add notification entity

            var notification = await _notificationService.CreateAsync(new Notification
            {
                ProfileID = friendRequest.SenderProfileID,
                NotificationText = $"{friendRequest.ReceiverProfile.DisplayName()} accepted your friend request",
                NotificationDate = DateTime.Now,
                IsRead = false,
            });

            await _hubContext.Clients.All
                .SendAsync($"Notification-{notification?.ProfileID}", notification);

            return friendRequest;
        }

        public async Task<FriendRequest> RejectFriendRequestAsync(RejectFriendRequestCommand requestCommand)
        {
            var friendRequest = await _unitOfWork
                .GetRepository<FriendRequest>()
                .GetByIdWithSpecAsync(new BaseSpecification<FriendRequest>(
                    x => x.FriendRequestID == requestCommand.FriendRequestID &&
                    x.ReceiverProfileID == requestCommand.ReceiverProfileID
                    )
                {
                    Includes = new() { x => x.SenderProfile, x => x.ReceiverProfile }
                });

            if (friendRequest == null)
                throw new ValidationException("Friend Request not found!");
            if (friendRequest.FriendRequestStatus is not FriendRequestStatus.Pending)
                throw new ValidationException("Friend Request Status should be pending to change it!");

            friendRequest.FriendRequestStatus = FriendRequestStatus.Reject;

            await _unitOfWork.GetRepository<FriendRequest>().UpdateAsync(friendRequest);

            await _unitOfWork.Complete();

            // send notification && add notification entity

            var notification = await _notificationService.CreateAsync(new Notification
            {
                ProfileID = friendRequest.SenderProfileID,
                NotificationText = $"{friendRequest.ReceiverProfile.DisplayName()} rejected your friend request",
                NotificationDate = DateTime.Now,
                IsRead = false,
            });


            await _hubContext.Clients.All
            .SendAsync($"Notification-{notification?.ProfileID}", notification);


            return friendRequest;
        }
    }
}
