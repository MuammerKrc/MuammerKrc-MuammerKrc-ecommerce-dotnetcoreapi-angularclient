using ECommerce.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Commands.AppUserCommands.LoginWithRefreshToken
{
    public class LoginWithRefreshTokenCommandResponse
    {
        public Token Token { get; set; }
    }
}
