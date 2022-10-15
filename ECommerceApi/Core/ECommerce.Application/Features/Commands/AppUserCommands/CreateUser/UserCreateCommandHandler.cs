using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Application.Abstractions.Services;
using ECommerce.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace ECommerce.Application.Features.Commands.AppUserCommands.CreateUser
{
    public class UserCreateCommandHandler : IRequestHandler<UserCreateCommandRequest, UserCreateCommandResponse>
    {
        private readonly IUserService _userService;

        public UserCreateCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<UserCreateCommandResponse> Handle(UserCreateCommandRequest request, CancellationToken cancellationToken)
        {
            var result = await _userService.CreateAsync(new Dtos.UserDto.CreateUser()
            {
                Email = request.Email,
                Name = request.Name,
                Password = request.Password,
                Surname = request.Surname
            });

            return new UserCreateCommandResponse()
            {
                Message = result.Message,
                Succeeded = result.Succeeded
            };
        }
    }
}
