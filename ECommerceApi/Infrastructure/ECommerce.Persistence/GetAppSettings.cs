using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace ECommerce.Persistence
{
    internal static class GetAppSettings
    {
        internal static string ConnectionString
        {
            get
            {
                ConfigurationManager configurationManager = new();
                configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../presentation/ecommerce.api"));
                configurationManager.AddJsonFile("appsettings.Development.json");
                return configurationManager.GetConnectionString("DefaultConnection");
            }
        }
    }
}
