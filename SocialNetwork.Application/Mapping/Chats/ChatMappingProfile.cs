using AutoMapper;
using SocialNetwork.Application.Features.Chats.Commands.Models;
using SocialNetwork.Application.Features.Chats.Commands.Responses;
using SocialNetwork.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Profile = AutoMapper.Profile;

namespace SocialNetwork.Application.Mapping.Chats
{
    public class ChatMappingProfile : Profile
    {
        public ChatMappingProfile() 
        {
            CreateMap<Chat, StartNewChatResponse>();
        }
    }
}
