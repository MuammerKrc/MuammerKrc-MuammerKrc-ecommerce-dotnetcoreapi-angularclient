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
using Google.Apis.Auth;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.VisualBasic;

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
        private ExternalLoginConfigurationModel tokenExternalLoginConfigurationModel;

        public AuthService(IOptions<TokenConfigurationModel> tokenOptions, IOptions<ExternalLoginConfigurationModel> externalOptions, IConfiguration configuration, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IUserService userService, ITokenService tokenService)
        {
            _configuration = configuration;
            _userManager = userManager;
            _signInManager = signInManager;
            _userService = userService;
            _tokenService = tokenService;
            tokenConfigurationModel = tokenOptions.Value;
            tokenExternalLoginConfigurationModel = externalOptions.Value;
        }

        public Task<Token> FacebookLoginAsync(string authToken)
        {
            throw new NotImplementedException();
        }

        public async Task<Token> GoogleLoginAsync(string idToken)
        {
            var settings = new GoogleJsonWebSignature.ValidationSettings()
            {
                Audience = new List<string> { tokenExternalLoginConfigurationModel.Google.Client_ID }
            };

            var payload = await GoogleJsonWebSignature.ValidateAsync(idToken, settings);

            var info = new UserLoginInfo("GOOGLE", payload.Subject, "GOOGLE");
            var user = await _userManager.FindByLoginAsync(info.LoginProvider, info.ProviderKey);
            return await CreateUserExternalAsync(user, payload.Email, payload.Name ?? "", info, payload);
        }

        private async Task<Token> CreateUserExternalAsync(AppUser user, string email, string name, UserLoginInfo info, GoogleJsonWebSignature.Payload payload)
        {
            bool result = user != null;
            if (user == null)
            {
                user = await _userManager.FindByEmailAsync(email);
                result = user != null;
                if (user == null)
                {
                    user = new()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Email = email,
                        UserName = Guid.NewGuid().ToString(),
                        NameSurname = payload?.Name ?? "" + " " + payload?.FamilyName ?? "",
                        Name = payload?.Name ?? "",
                        Surname = payload?.FamilyName ?? ""
                    };
                    var identityResult = await _userManager.CreateAsync(user);
                    result = identityResult.Succeeded;
                }
            }
            if (result)
            {
                await _userManager.AddLoginAsync(user, info);
                Token token = _tokenService.CreateAccessToken(user);
                await _userService.UpdateRefreshTokenAsync(token.RefreshToken, user,
                    token.Expiration.AddMinutes(tokenConfigurationModel.RefreshTokenExpirationTime));
                return token;
            }
            throw new Exception("Invalid external authentication.");
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
