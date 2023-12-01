using AutoMapper;
using MediatR;
using SocialNetwork.Application.Features.Chats.Commands.Models;
using SocialNetwork.Application.Features.Chats.Commands.Responses;
using SocialNetwork.Application.Services.Contract;
using SocialNetwork.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Application.Features.Chats.Commands.Handlers
{
    public class ChatCommandHandler : IRequestHandler<StartNewChatCommand, StartNewChatResponse>,
                                        IRequestHandler<SendNewMessageCommand, SendNewMessageResponse>
    {
        private readonly IChatService _chatService;
        private readonly IMapper _mapper;

        public ChatCommandHandler(IChatService chatService, IMapper mapper)
        {
            this._chatService = chatService;
            this._mapper = mapper;
        }

        public async Task<StartNewChatResponse> Handle(StartNewChatCommand request, CancellationToken cancellationToken)
        {
            var newChat = await _chatService.StartNewChatAsync(request);

            var chatResponse = _mapper.Map<StartNewChatResponse>(newChat);

            return chatResponse;
        }

        public async Task<SendNewMessageResponse> Handle(SendNewMessageCommand request, CancellationToken cancellationToken)
        {
            //var newMessage = await _chatService.SendNewMessageAsync(request);

            throw new NotImplementedException();
        }

        //public async Task Handle(SendNewMessageCommand request, CancellationToken cancellationToken)
        //{
        //    await _chatService.SendNewMessageAsync(request);
        //}
    }
}
