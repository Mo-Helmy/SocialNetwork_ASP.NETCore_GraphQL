using Microsoft.AspNetCore.SignalR;
using SocialNetwork.Domain.Entities;
using SocialNetwork.Infrastructure.UnitOfWorks.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Application.Hubs
{
    public class NotificationHub : Hub
    {

        public NotificationHub()
        {
           
        }

        public async Task ReceiveNotification(Notification notification)
        {
            await Clients.User(notification.ProfileID).SendAsync("ReceiveNotification", notification);
        }
    }
}
