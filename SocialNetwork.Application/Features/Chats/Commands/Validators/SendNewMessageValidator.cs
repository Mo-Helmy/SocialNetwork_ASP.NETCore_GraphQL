using FluentValidation;
using Microsoft.IdentityModel.Tokens;
using SocialNetwork.Application.Features.Chats.Commands.Models;
using SocialNetwork.Domain.Entities;
using SocialNetwork.Infrastructure.Specifications;
using SocialNetwork.Infrastructure.UnitOfWorks.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace SocialNetwork.Application.Features.Chats.Commands.Validators
{
    public class SendNewMessageValidator : AbstractValidator<SendNewMessageCommand>
    {


        public SendNewMessageValidator(IUnitOfWork unitOfWork)
        {
            //RuleFor(x => x.SenderProfileId)

            RuleFor(x => x.ChatID)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x)
                .MustAsync(async Task<bool> (command, senderProfileId) =>
                {
                    var chat = await unitOfWork.GetRepository<Chat>().GetByIdWithSpecAsync(
                        new BaseSpecification<Chat>(x => x.ChatID == command.ChatID)
                        { Includes = new List<System.Linq.Expressions.Expression<Func<Chat, object>>>() { x => x.Participants } }
                        );

                    return chat is not null && chat.Participants.Any(x => x.ProfileID == command.SenderProfileId);
                }).WithMessage("chat is not exist or your profileId is not participant in this chat");

            RuleFor(x => x.MessageText)
                .Must((command, message) =>
                    string.IsNullOrEmpty(message) ?  command.Medias is not null && command.Medias.Count() > 0 : !string.IsNullOrEmpty(message)
                ).WithMessage("if messageText is null or empty then mediaPath and mediaType must have value else message text must have value!");

        }
    }
}
