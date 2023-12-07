using AutoMapper;
using SocialNetwork.Application.Features.Chats.Commands.Models;
using SocialNetwork.Application.Features.Chats.Commands.Responses;
using SocialNetwork.Application.Features.Profiles.Commands.Models;
using SocialNetwork.Application.Features.Profiles.Commands.Responses;
using SocialNetwork.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Application.Mapping.Profiles
{
    public class ProfileMappingProfile : AutoMapper.Profile
    {
        public ProfileMappingProfile()
        {
            CreateMap<AddNewProfileCommand, Domain.Entities.Profile>();
            CreateMap<Domain.Entities.Profile, AddNewProfileResponse>();
        }
    }
}
