using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Application.Abstractions;
using ECommerce.SignalR.Hubs;
using Microsoft.AspNetCore.Builder;

namespace ECommerce.SignalR
{
    public static class MappedHubs
    {
        public static void MapHubs(this WebApplication application)
        {
            application.MapHub<ProductHub>("/products-hub");
        }
    }
}
