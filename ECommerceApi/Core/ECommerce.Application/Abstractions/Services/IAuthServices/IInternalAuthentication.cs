using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Application.Dtos;

namespace ECommerce.Application.Abstractions.Services.AuthServices
{
    public interface IInternalAuthentication
    {
        Task<Token> LoginAsync(string usernameOrEmail, string password);
        Task<Token> RefreshTokenLoginAsync(string refreshToken);
    }
}
