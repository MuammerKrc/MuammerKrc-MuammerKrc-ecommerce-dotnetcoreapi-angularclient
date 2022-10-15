using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Application.Dtos;

namespace ECommerce.Application.Abstractions.Services.AuthServices
{
    public interface IExternalAuthentication
    {
        Task<Token> FacebookLoginAsync(string authToken, int accessTokenLifeTime);
        Task<Token> GoogleLoginAsync(string idToken, int accessTokenLifeTime);
    }
}
