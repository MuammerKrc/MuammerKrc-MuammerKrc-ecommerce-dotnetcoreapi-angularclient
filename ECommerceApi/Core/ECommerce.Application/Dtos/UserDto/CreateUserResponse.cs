using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Dtos.UserDto
{
    public class CreateUserResponse
    {
        public bool Succeeded { get; set; }
        public string Message { get; set; }
    }
}
