using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Application.Features.Profiles.Commands.Models;
using SocialNetwork.Application.Features.Profiles.Commands.Responses;
using System.Security.Claims;

namespace SocialNetwork.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfilesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProfilesController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<AddNewProfileResponse>> CreateNewProfile(AddNewProfileCommand profileCommand)
        {
            var userId = User.FindFirstValue("uid");

            profileCommand.ProfileId = userId;

            return new CreatedResult(string.Empty, await _mediator.Send(profileCommand));
        }

        [Authorize]
        [HttpPut]
        public async Task<ActionResult<AddNewProfileResponse>> UpdateProfile(UpdateProfileCommand profileCommand)
        {
            var userId = User.FindFirstValue("uid");

            profileCommand.ProfileId = userId;

            return Ok(await _mediator.Send(profileCommand));
        }
    }
}
