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
    public class NotificationService : GenericService<Notification>, INotificationService
    {
        public NotificationService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
