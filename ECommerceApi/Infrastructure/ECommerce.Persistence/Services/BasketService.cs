using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Application.Abstractions.Services;
using ECommerce.Application.Dtos.BasketDtos;
using ECommerce.Application.Repositories.IBasketItemRepositories;
using ECommerce.Application.Repositories.IBasketRepositories;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Entities.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace ECommerce.Persistence.Services
{
    public class BasketService:IBasketService
    {
        readonly IHttpContextAccessor _httpContextAccessor;
        readonly UserManager<AppUser> _userManager;
        //readonly IOrderReadRepository _orderReadRepository;
        readonly IBasketWriteRepository _basketWriteRepository;
        readonly IBasketReadRepository _basketReadRepository;
        readonly IBasketItemWriteRepository _basketItemWriteRepository;
        readonly IBasketItemReadRepository _basketItemReadRepository;

        public Task<List<BasketItem>> GetBasketItemsAsync()
        {
            throw new NotImplementedException();

        }

        public Task AddItemToBasketAsync(CreateBasketItem basketItem)
        {
            throw new NotImplementedException();
        }

        public Task UpdateQuantityAsync(UpdateBasketItem basketItem)
        {
            throw new NotImplementedException();
        }

        public Task RemoveBasketItemAsync(string basketItemId)
        {
            throw new NotImplementedException();
        }

        public Basket? GetUserActiveBasket { get; }
    }
}
