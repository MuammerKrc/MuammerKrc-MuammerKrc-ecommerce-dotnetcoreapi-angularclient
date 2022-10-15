using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Application.Abstractions.Services;
using ECommerce.Application.ConfigurationModels;
using ECommerce.Application.Dtos;
using ECommerce.Domain.Entities.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace ECommerce.Infrastructure.Services
{
    public class TokenService : ITokenService
    {
        
        private TokenConfigurationModel tokenConfigurationModel;
        public TokenService(IOptions<TokenConfigurationModel> options)
        {
            tokenConfigurationModel = options.Value;
        }

        private SigningCredentials GetSigninCredentials(string key)
        {
            var keyByte = Encoding.UTF8.GetBytes(key);
            var symmetricKey = new SymmetricSecurityKey(keyByte);
            var signinCredentials = new SigningCredentials(symmetricKey, SecurityAlgorithms.HmacSha256Signature);
            return signinCredentials;
        }

        public Token CreateAccessToken(AppUser appUser)
        {
            SigningCredentials signingCredentials = GetSigninCredentials(tokenConfigurationModel.SecurityKey);
            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                audience: tokenConfigurationModel.Audience,
                issuer: tokenConfigurationModel.Issuer,
                claims: new List<Claim>() { new Claim(ClaimTypes.Name, appUser.Email) },
                //claims:null,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddMinutes(tokenConfigurationModel.AccessTokenExpirationTime),
                signingCredentials: signingCredentials
            );
            var handler = new JwtSecurityTokenHandler();
            var accessToken = handler.WriteToken(jwtSecurityToken);
            var token = new Token()
            {
                AccessToken = accessToken,
                RefreshToken = Guid.NewGuid().ToString(),
                Expiration = DateTime.UtcNow.AddMinutes(tokenConfigurationModel.AccessTokenExpirationTime)
            };
            return token;
        }

        
    }
}
