using ECommerce.Application.Features.Commands.AppUserCommands.GoogleLogin;
using ECommerce.Application.Features.Commands.AppUserCommands.LoginUser;
using ECommerce.Application.Features.Commands.AppUserCommands.LoginWithRefreshToken;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginCommandRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> GoogleLogin(GoogleLoginCommandRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> LoginWithRefreshToken(LoginWithRefreshTokenCommandRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }
    }

}
