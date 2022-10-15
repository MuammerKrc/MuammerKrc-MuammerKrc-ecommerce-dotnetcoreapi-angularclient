using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Application.Abstractions.Services;
using ECommerce.Application.Abstractions.Services.IAuthServices;
using ECommerce.Application.ConfigurationModels;
using ECommerce.Application.Dtos;
using ECommerce.Application.Exceptions;
using ECommerce.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace ECommerce.Persistence.Services
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;
        private TokenConfigurationModel tokenConfigurationModel;

        public AuthService(IOptions<TokenConfigurationModel> tokenOptions, IConfiguration configuration, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IUserService userService, ITokenService tokenService)
        {
            _configuration = configuration;
            _userManager = userManager;
            _signInManager = signInManager;
            _userService = userService;
            _tokenService = tokenService;
            tokenConfigurationModel = tokenOptions.Value;
        }

        public Task<Token> FacebookLoginAsync(string authToken, int accessTokenLifeTime)
        {
            throw new NotImplementedException();
        }

        public Task<Token> GoogleLoginAsync(string idToken, int accessTokenLifeTime)
        {
            throw new NotImplementedException();
        }

        public async Task<Token> LoginAsync(string usernameOrEmail, string password)
        {
            AppUser user = await _userManager.FindByEmailAsync(usernameOrEmail);

            if (user == null)
                throw new UserNotFoundExceptions();
            SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, password, false);
            if (result.Succeeded)
            {
                Token token = _tokenService.CreateAccessToken(user);
                await _userService.UpdateRefreshTokenAsync(token.RefreshToken, user,
                    token.Expiration.AddMinutes(tokenConfigurationModel.RefreshTokenExpirationTime));
                return token;
            }

            throw new AuthenticationErrorException();
        }

        public async Task<Token> RefreshTokenLoginAsync(string refreshToken)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(e => e.RefreshToken == refreshToken && e.RefreshTokenEndDate > DateTime.UtcNow);
            if (user != null)
            {
                Token token = _tokenService.CreateAccessToken(user);
                await _userService.UpdateRefreshTokenAsync(token.RefreshToken, user,
                    token.Expiration.AddMinutes(tokenConfigurationModel.RefreshTokenExpirationTime));
                return token;
            }
            else
                throw new UserNotFoundExceptions();
        }

        public Task PasswordResetAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<bool> VerifyResetTokenAsync(string resetToken, string userId)
        {
            throw new NotImplementedException();
        }
    }
}
