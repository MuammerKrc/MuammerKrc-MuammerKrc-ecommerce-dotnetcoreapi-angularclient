using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Application.Abstractions.Hubs;
using ECommerce.SignalR.HubServices;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.SignalR
{
    public static class ServiceRegistration
    {
        public static void AddSignalRServiceRegistration(this IServiceCollection services)
        {
            services.AddTransient<IProductHubService, ProductHubService>();
            services.AddSignalR();
        }

    }
}
