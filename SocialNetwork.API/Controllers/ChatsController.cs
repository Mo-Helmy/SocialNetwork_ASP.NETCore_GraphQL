using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Application.Features.Chats.Commands.Models;
using SocialNetwork.Application.Features.Chats.Commands.Responses;
using System.Security.Claims;

namespace SocialNetwork.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ChatsController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [Authorize]
        [HttpPost("startNewChat")]
        public async Task<ActionResult<StartNewChatResponse>> StartNewChat(StartNewChatCommand newChatCommand)
        {
            var profileId = User.FindFirstValue("uid")!;
            newChatCommand.SenderProfileId = profileId;

            var chatResponse = await _mediator.Send(newChatCommand);

            return new CreatedResult(string.Empty, chatResponse);
        }

        [Authorize]
        [HttpPost("sendNewMessage")]
        public async Task<ActionResult> SendNewMessage([FromBody] SendNewMessageCommand messageCommand)
        {
            var profileId = User.FindFirstValue("uid")!;
            messageCommand.SenderProfileId = profileId;

            await _mediator.Send(messageCommand);

            return new CreatedResult(string.Empty, null);
        }
    }
}
