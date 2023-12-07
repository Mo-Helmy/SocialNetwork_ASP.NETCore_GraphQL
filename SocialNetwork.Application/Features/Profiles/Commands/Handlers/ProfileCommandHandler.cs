using AutoMapper;
using MediatR;
using SocialNetwork.Application.Features.Profiles.Commands.Models;
using SocialNetwork.Application.Features.Profiles.Commands.Responses;
using SocialNetwork.Application.Services.Contract;
using SocialNetwork.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Profile = SocialNetwork.Domain.Entities.Profile;

namespace SocialNetwork.Application.Features.Profiles.Commands.Handlers
{
    public class ProfileCommandHandler : IRequestHandler<AddNewProfileCommand, AddNewProfileResponse>,
                                        IRequestHandler<UpdateProfileCommand, AddNewProfileResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProfileService _profileService;

        public ProfileCommandHandler(IMapper mapper, IProfileService profileService)
        {
            this._mapper = mapper;
            this._profileService = profileService;
        }


        public async Task<AddNewProfileResponse> Handle(AddNewProfileCommand request, CancellationToken cancellationToken)
        {
            var profileEntity = _mapper.Map<Profile>(request);

            profileEntity = await _profileService.CreateAsync(profileEntity);

            return _mapper.Map<AddNewProfileResponse>(profileEntity);
        }

        public async Task<AddNewProfileResponse> Handle(UpdateProfileCommand request, CancellationToken cancellationToken)
        {
            var profileEntity = await _profileService.UpdateAsync(request.ProfileId!, request);

            return _mapper.Map<AddNewProfileResponse>(profileEntity);
        }
    }
}
