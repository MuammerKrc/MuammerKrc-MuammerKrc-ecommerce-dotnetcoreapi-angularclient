using ECommerce.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Commands.AppUserCommands.LoginUser
{
    public class UserLoginCommandResponse
    {
    }
    public class LoginUserSuccessCommandResponse : UserLoginCommandResponse
    {
        public Token Token { get; set; }
    }
    public class LoginUserErrorCommandResponse : UserLoginCommandResponse
    {
        public string Message { get; set; }
    }
}
