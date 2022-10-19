using ECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Application.Dtos.BasketDtos;

namespace ECommerce.Application.Abstractions.Services
{
    public interface IBasketService
    {
        public Task<List<BasketItem>> GetBasketItemsAsync();
        public Task AddItemToBasketAsync(CreateBasketItem basketItem);
        public Task UpdateQuantityAsync(UpdateBasketItem basketItem);
        public Task RemoveBasketItemAsync(Guid basketItemId);
        public Basket? GetUserActiveBasket { get; }
    }
}
