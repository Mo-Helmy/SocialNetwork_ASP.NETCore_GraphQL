using SocialNetwork.Domain.Entities.Enums;

namespace SocialNetwork.Application.Features.Chats.Commands.Models
{
    public class SendNewMediaCommand
    {
        public MediaType MediaType { get; set; }

        public string MediaPath { get; set; }
    }
}