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
    public class ProfileService : GenericService<Profile>, IProfileService
    {
        public ProfileService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
