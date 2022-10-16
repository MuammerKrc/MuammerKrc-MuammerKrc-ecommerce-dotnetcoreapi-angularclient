using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace ECommerce.Application.Features.Commands.AppUserCommands.LoginWithRefreshToken
{
    public class LoginWithRefreshTokenCommandRequest:IRequest<LoginWithRefreshTokenCommandResponse>
    {
        public string RefreshToken { get; set; }

    }
}
