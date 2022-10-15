using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Application.Abstractions.Services;
using ECommerce.Application.Dtos.UserDto;
using ECommerce.Application.Exceptions;
using ECommerce.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace ECommerce.Persistence.Services
{
    public class UserService:IUserService
    {
        private readonly UserManager<AppUser> _userManager;

        public UserService(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<CreateUserResponse> CreateAsync(CreateUser model)
        {
            try
            {
                IdentityResult result = await _userManager.CreateAsync(new AppUser()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = model.Name,
                    Surname = model.Surname,
                    NameSurname = model.Name+" "+model.Surname,
                    Email = model.Email,
                    UserName = Guid.NewGuid().ToString()
                }, model.Password);
                CreateUserResponse response = new() { Succeeded = result.Succeeded };
                if (!response.Succeeded)
                    foreach (var error in result.Errors)
                    {
                        response.Message += $"{error.Description}\n";
                    }

                return response;
            }
            catch (Exception e)
            {
                throw new UserCreateException("Kişi oluşturulurken bir hata meydana geldi");
            }
            
        }

        public Task UpdateRefreshTokenAsync(string refreshToken, AppUser user, DateTime accessTokenDate, int addOnAccessTokenDate)
        {
            throw new NotImplementedException();
        }

        public Task UpdatePasswordAsync(string userId, string resetToken, string newPassword)
        {
            throw new NotImplementedException();
        }
    }
}
