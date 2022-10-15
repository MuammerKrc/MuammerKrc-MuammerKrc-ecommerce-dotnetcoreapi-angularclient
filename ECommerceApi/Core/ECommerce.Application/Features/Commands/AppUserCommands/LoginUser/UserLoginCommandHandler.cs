using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Application.Abstractions.Services.IAuthServices;
using MediatR;

namespace ECommerce.Application.Features.Commands.AppUserCommands.LoginUser
{
    public class UserLoginCommandHandler : IRequestHandler<UserLoginCommandRequest, UserLoginCommandResponse>
    {
        private readonly IAuthService _authService;

        public UserLoginCommandHandler(IAuthService authService)
        {
            this._authService = authService;
        }

        public async Task<UserLoginCommandResponse> Handle(UserLoginCommandRequest request, CancellationToken cancellationToken)
        {
            var token = await _authService.LoginAsync(request.Email, request.Password);
            return new LoginUserSuccessCommandResponse()
            {
                Token = token
            };

        }

    }
}
