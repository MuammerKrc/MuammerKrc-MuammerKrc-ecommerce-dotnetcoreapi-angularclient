using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Application.Abstractions.Services.IAuthServices;
using MediatR;

namespace ECommerce.Application.Features.Commands.AppUserCommands.GoogleLogin
{
    public class GoogleLoginCommandHandler:IRequestHandler<GoogleLoginCommandRequest,GoogleLoginCommandResponse>
    {
        private readonly IAuthService _authService;

        public GoogleLoginCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<GoogleLoginCommandResponse> Handle(GoogleLoginCommandRequest request, CancellationToken cancellationToken)
        {
            var result=await _authService.GoogleLoginAsync(request.IdToken);
            return new GoogleLoginCommandResponse()
            {
                Token = result
            };
        }

    }
}
