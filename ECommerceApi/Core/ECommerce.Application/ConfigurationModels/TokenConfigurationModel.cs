using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace ECommerce.Application.ConfigurationModels
{
    public class TokenConfigurationModel
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public string SecurityKey { get; set; }
        public int AccessTokenExpirationTime { get; set; }
        public int RefreshTokenExpirationTime { get; set; }
    }
}
