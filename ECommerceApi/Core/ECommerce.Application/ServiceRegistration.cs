using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Application.ConfigurationModels;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServiceRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(typeof(ServiceRegistration));

            //Configuration
            services.Configure<TokenConfigurationModel>(configuration.GetSection("Token"));
            services.Configure<ExternalLoginConfigurationModel>(configuration.GetSection("ExternalLoginSettings"));

        }
    }
}
