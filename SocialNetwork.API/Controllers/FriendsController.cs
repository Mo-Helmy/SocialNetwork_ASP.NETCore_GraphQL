using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Application.Features.Friends.Commands.Models;
using SocialNetwork.Application.Responses;
using System.Security.Claims;

namespace SocialNetwork.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FriendsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FriendsController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [Authorize]
        [HttpPost("sendFriendRequest")]
        public async Task<ActionResult<BaseResponse<string>>> SendFriendRequest(SendFriendRequestCommand requestCommand)
        {
            var userID = User.FindFirstValue("uid");
            requestCommand.SenderProfileID = userID;

            return Created(string.Empty, await _mediator.Send(requestCommand));
        }


        [Authorize]
        [HttpPost("deleteFriendRequest")]
        public async Task<ActionResult<BaseResponse<string>>> DeleteFriendRequest(DeleteFriendRequestCommand requestCommand)
        {
            var userID = User.FindFirstValue("uid");
            requestCommand.SenderProfileID = userID;

            return Created(string.Empty, await _mediator.Send(requestCommand));
        }


        [Authorize]
        [HttpPost("acceptFriendRequest")]
        public async Task<ActionResult<BaseResponse<string>>> AcceptFriendRequest(AcceptFriendRequestCommand requestCommand)
        {
            var userID = User.FindFirstValue("uid");
            requestCommand.ReceiverProfileID = userID;

            return Ok(await _mediator.Send(requestCommand));
        }

        [Authorize]
        [HttpPost("rejectFriendRequest")]
        public async Task<ActionResult<BaseResponse<string>>> RejectFriendRequest(RejectFriendRequestCommand requestCommand)
        {
            var userID = User.FindFirstValue("uid");
            requestCommand.ReceiverProfileID = userID;

            return Ok(await _mediator.Send(requestCommand));
        }
    }
}
