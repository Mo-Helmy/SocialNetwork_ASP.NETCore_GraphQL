using SocialNetwork.Domain.Entities;
using SocialNetwork.Infrastructure.Repositories.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Application.Services
{
    public class ProfileService
    {
        private readonly IGenericRepository<Profile> _profileRepo;

        public ProfileService(IGenericRepository<Profile> profileRepo)
        {
            this._profileRepo = profileRepo;
        }

        public IQueryable<Profile> GetProfiles()
        {
            return _profileRepo.GetAllAsync();
        }

    }
}
