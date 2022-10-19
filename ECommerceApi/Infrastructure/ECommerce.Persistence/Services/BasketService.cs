using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Application.Abstractions.Services;
using ECommerce.Application.Dtos.BasketDtos;
using ECommerce.Application.Repositories.IBasketItemRepositories;
using ECommerce.Application.Repositories.IBasketRepositories;
using ECommerce.Application.Repositories.IOrderRepositories;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Entities.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Persistence.Services
{
    public class BasketService : IBasketService
    {

        readonly IHttpContextAccessor _httpContextAccessor;
        readonly UserManager<AppUser> _userManager;
        readonly IOrderReadRepository _orderReadRepository;
        readonly IBasketWriteRepository _basketWriteRepository;
        readonly IBasketReadRepository _basketReadRepository;
        readonly IBasketItemWriteRepository _basketItemWriteRepository;
        readonly IBasketItemReadRepository _basketItemReadRepository;


        public BasketService(IHttpContextAccessor httpContextAccessor, UserManager<AppUser> userManager, IOrderReadRepository orderReadRepository, IBasketWriteRepository basketWriteRepository, IBasketReadRepository basketReadRepository, IBasketItemWriteRepository basketItemWriteRepository, IBasketItemReadRepository basketItemReadRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
            _orderReadRepository = orderReadRepository;
            _basketWriteRepository = basketWriteRepository;
            _basketReadRepository = basketReadRepository;
            _basketItemWriteRepository = basketItemWriteRepository;
            _basketItemReadRepository = basketItemReadRepository;
        }

        private async Task<Basket?> CurrentUser()
        {
            var email = _httpContextAccessor?.HttpContext?.User?.Identity?.Name;
            if (!string.IsNullOrEmpty(email))
            {
                AppUser? user = await _userManager.Users.Include(i => i.Baskets)
                    .FirstOrDefaultAsync(u => u.Email.ToLower() == email.ToLower());
                var _basket = from basket in user.Baskets
                              join order in _orderReadRepository._entity
                                  on basket.Id equals order.Id into BasketOrders
                              from order in BasketOrders.DefaultIfEmpty()
                              select new
                              {
                                  Basket = basket,
                                  Order = order
                              };

                Basket? targetBasket = null;
                if (_basket.Any(b => b.Order is null))
                    targetBasket = _basket.FirstOrDefault(b => b.Order is null)?.Basket;
                else
                {
                    targetBasket = new();
                    user.Baskets.Add(targetBasket);
                }

                await _basketWriteRepository.SaveAsync();
                return targetBasket;
            }
            throw new Exception("Beklenmeyen bir hatayla karşılaşıldı...");
        }
        public async Task<List<BasketItem>> GetBasketItemsAsync()
        {
            Basket? basket = await CurrentUser();
            Basket? result = await _basketReadRepository._entity
                .Include(b => b.BasketItems)
                .ThenInclude(bi => bi.Product)
                .FirstOrDefaultAsync(b => b.Id == basket.Id);

            return result.BasketItems
                .ToList();
        }

        public Task AddItemToBasketAsync(CreateBasketItem basketItem)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateQuantityAsync(UpdateBasketItem basketItem)
        {
            BasketItem? _basketItem = await _basketItemReadRepository.GetByIdAsync(basketItem.BasketItemId);
            if (_basketItem != null)
            {
                _basketItem.Quantity = basketItem.Quantity;
                await _basketItemWriteRepository.SaveAsync();
            }
        }

        public async Task RemoveBasketItemAsync(Guid basketItemId)
        {
            BasketItem? basketItem = await _basketItemReadRepository.GetByIdAsync(basketItemId);
            if (basketItem != null)
            {
                _basketItemWriteRepository.Remove(basketItem);
                await _basketItemWriteRepository.SaveAsync();
            }
        }

        public Basket? GetUserActiveBasket
        {
            get
            {
                Basket? basket = CurrentUser().Result;
                return basket;
            }
        }
    }
}
