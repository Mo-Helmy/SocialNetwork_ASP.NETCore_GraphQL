using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Application.Hubs
{
    public class CustomUserIdProvider : IUserIdProvider
    {
        public virtual string GetUserId(HubConnectionContext connection)
        {
            return connection.User?.FindFirstValue("uid");
        }
    }
}
