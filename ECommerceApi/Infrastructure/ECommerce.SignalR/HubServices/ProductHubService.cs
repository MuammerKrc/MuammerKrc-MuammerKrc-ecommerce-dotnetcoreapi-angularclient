using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Application.Abstractions.Hubs;
using ECommerce.SignalR.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace ECommerce.SignalR.HubServices
{
    public class ProductHubService : IProductHubService
    {
        private readonly IHubContext<ProductHub> _productContext;

        public ProductHubService(IHubContext<ProductHub> productContext)
        {
            _productContext = productContext;
        }

        public async Task ProductAddedMessageAsync(string message)
        {
            await _productContext.Clients.All.SendAsync(ReceiveFunctionNames.ProductAddedMessage, $"Ürün eklendi {message}");
        }
    }
}
