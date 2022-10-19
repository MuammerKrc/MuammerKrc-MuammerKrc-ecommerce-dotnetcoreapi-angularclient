using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Application.Abstractions.Services;
using ETicaretAPI.Application.DTOs.Order;

namespace ECommerce.Persistence.Services
{
    public class OrderService:IOrderService
    {
        public Task CreateOrderAsync(CreateOrder createOrder)
        {
            throw new NotImplementedException();
        }

        public Task<ListOrder> GetAllOrdersAsync(int page, int size)
        {
            throw new NotImplementedException();
        }

        public Task<SingleOrder> GetOrderByIdAsync(string id)
        {
            throw new NotImplementedException();
        }
    }
}
