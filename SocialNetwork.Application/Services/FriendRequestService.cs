using Microsoft.AspNetCore.SignalR;
using SocialNetwork.Application.Hubs;
using SocialNetwork.Application.Services.Contract;
using SocialNetwork.Domain.Entities;
using SocialNetwork.Infrastructure.UnitOfWorks.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Application.Services
{
    public class FriendRequestService : GenericService<FriendRequest>, IFriendRequestService
    {
        private readonly INotificationService _notificationService;
        private readonly IHubContext<NotificationHub> _hubContext;

        public FriendRequestService(
            IUnitOfWork unitOfWork, 
            INotificationService notificationService, 
            IHubContext<NotificationHub> hubContext
            ) : base(unitOfWork)
        {
            this._notificationService = notificationService;
            this._hubContext = hubContext;
        }

        public override async Task<FriendRequest?> CreateAsync(FriendRequest entity)
        {
            await base.CreateAsync(entity);

            var senderProfile = await _unitOfWork.GetRepository<Profile>().GetByIdAsync(entity.SenderProfileID);

            var notification = await _notificationService.CreateAsync(new Notification
            {
                ProfileID = entity.ReceiverProfileID,
                NotificationText = $"{senderProfile!.DisplayName()} send you friend request",
                NotificationDate = DateTime.Now,
                IsRead = false,
            });

            await _hubContext.Clients.All
                .SendAsync($"Notification-{entity.ReceiverProfileID}", notification);

            return entity;
        }
    }
}
