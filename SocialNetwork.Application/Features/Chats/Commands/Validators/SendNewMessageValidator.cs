using FluentValidation;
using Microsoft.IdentityModel.Tokens;
using SocialNetwork.Application.Features.Chats.Commands.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Application.Features.Chats.Commands.Validators
{
    public class SendNewMessageValidator : AbstractValidator<SendNewMessageCommand>
    {
        public SendNewMessageValidator()
        {
            //RuleFor(x => x.SenderProfileId)

            RuleFor(x => x.ChatID)
                .NotNull()
                .NotEmpty();

            //RuleFor(x => x.MessageText)
            //    .Must((command, message) => 
            //        string.IsNullOrEmpty(message) ? !command.MediaPath.IsNullOrEmpty() && !command.MediaType.HasValue : !string.IsNullOrEmpty(message)
            //    ).WithMessage("if messageText is null or empty then mediaPath and mediaType must have value else message text must have value!");

            RuleFor(x => x.MessageText)
                .Must((command, message) =>
                    string.IsNullOrEmpty(message) ?  command.Medias is not null && command.Medias.Count() > 0 : !string.IsNullOrEmpty(message)
                ).WithMessage("if messageText is null or empty then mediaPath and mediaType must have value else message text must have value!");

        }
    }
}
