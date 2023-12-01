using SocialNetwork.Application.Features.Chats.Commands.Models;
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
    public class ChatService : GenericService<Chat>, IChatService
    {
        public ChatService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<Chat> StartNewChatAsync(StartNewChatCommand chatCommand)
        {
            // 1. create new chat entity
            // 2. Create chatParticipant entities
            // 3. Create chatMessage entity
            var newChat = await _unitOfWork.GetRepository<Chat>().CreateAsync(new Chat()
            {
                StartDate = DateTime.Now,
                Participants = new List<ChatParticipant>()
                {
                    new ChatParticipant()
                    {
                        ProfileID = chatCommand.SenderProfileId
                    },
                    new ChatParticipant()
                    {
                        ProfileID = chatCommand.recivererProfileId,
                    }
                },
                Messages = new List<Message>()
                {
                    new Message()
                    {
                        SenderProfileID = chatCommand.SenderProfileId,
                        MessageText = chatCommand.MessageText,
                        SendDate = DateTime.Now,
                    }
                }
            });

            await _unitOfWork.Complete();

            return newChat;
        }

        public async Task SendNewMessageAsync(SendNewMessageCommand newMessageCommand)
        {
            // add new message
            var newMessage = await _unitOfWork.GetRepository<Message>().CreateAsync(new Message()
            {
                ChatID = newMessageCommand.ChatID,
                MessageText = newMessageCommand.MessageText,
                SenderProfileID = newMessageCommand.SenderProfileId,
                SendDate = DateTime.Now,
            });

            // add media if exist
            if(newMessageCommand.Medias is not null && newMessageCommand.Medias.Any())
            {
                foreach (var item in newMessageCommand.Medias)
                {
                    await _unitOfWork.GetRepository<MessageMedia>().CreateAsync(new MessageMedia
                    {
                        Path = item.MediaPath,
                        Type = item.MediaType,
                        MessageId = newMessage.MessageID,
                        ProfileId = newMessageCommand.SenderProfileId,
                        UploadDate = DateTime.Now
                    });
                }
            }

            await _unitOfWork.Complete();
        }
    }
}
