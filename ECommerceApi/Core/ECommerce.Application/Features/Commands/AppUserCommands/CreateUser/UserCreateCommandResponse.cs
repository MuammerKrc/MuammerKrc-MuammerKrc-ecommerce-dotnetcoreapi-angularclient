using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Commands.AppUserCommands.CreateUser
{
    public class UserCreateCommandResponse
    {
        public bool Succeeded { get; set; } = false;
        public string Message { get; set; }
    }
}
