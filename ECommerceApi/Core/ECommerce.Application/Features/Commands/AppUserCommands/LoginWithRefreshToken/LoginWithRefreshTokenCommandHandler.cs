using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Application.Abstractions.Services.IAuthServices;
using ECommerce.Application.Dtos;
using MediatR;

namespace ECommerce.Application.Features.Commands.AppUserCommands.LoginWithRefreshToken
{
    public class LoginWithRefreshTokenCommandHandler : IRequestHandler<LoginWithRefreshTokenCommandRequest, LoginWithRefreshTokenCommandResponse>
    {
        readonly IAuthService _authService;

        public LoginWithRefreshTokenCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<LoginWithRefreshTokenCommandResponse> Handle(LoginWithRefreshTokenCommandRequest request, CancellationToken cancellationToken)
        {
            Token token = await _authService.RefreshTokenLoginAsync(request.RefreshToken);
            return new()
            {
                Token = token
            };
        }
    }
}
