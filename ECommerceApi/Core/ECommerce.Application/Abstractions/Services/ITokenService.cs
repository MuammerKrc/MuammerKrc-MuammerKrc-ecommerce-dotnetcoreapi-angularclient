using ECommerce.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Application.Dtos;

namespace ECommerce.Application.Abstractions.Services
{
    public interface ITokenService
    {
        Token CreateAccessToken(AppUser appUser);
    }
}
