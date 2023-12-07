using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using SocialNetwork.Application.Features.Chats.Commands.Models;
using SocialNetwork.Application.Services.Contract;
using SocialNetwork.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Application.Hubs
{
    [Authorize]
    public class ChatHub : Hub
    {
        private readonly IChatService _chatService;
        private readonly IHttpContextAccessor _httpContext;
        private readonly IMapper _mapper;

        public ChatHub(IChatService chatService, IHttpContextAccessor httpContext, IMapper mapper)
        {
            this._chatService = chatService;
            this._httpContext = httpContext;
            this._mapper = mapper;
        }

        public async Task Send(SendNewMessageCommand messageCommand)
        {
            var profileId = _httpContext.HttpContext?.User.FindFirstValue("uid");
            messageCommand.SenderProfileId = profileId;

            var newMessage = await _chatService.SendNewMessageAsync(messageCommand);

            await Clients.Others.SendAsync($"Chat-{newMessage.ChatID}", newMessage);
        }

        public async Task React(ReactToMessageCommand reactCommand)
        {
            var profileId = _httpContext.HttpContext?.User.FindFirstValue("uid");
            reactCommand.ProfileID = profileId;

            var reaction = _mapper.Map<MessageReaction>(reactCommand);

            await _chatService.ReactToMessageAsync(reaction);

            await Clients.Others.SendAsync($"Chat-{reactCommand.ChatId}", reaction);
        }


        
    }
}
