using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.ConfigurationModels
{
    public class ExternalLoginConfigurationModel
    {
        public FacebookConfigurationModel Facebook { get; set; }
        public GoogleConfigurationModel Google { get; set; }
    }

    public class FacebookConfigurationModel
    {
        public string Client_ID { get; set; }
        public string Client_Secret { get; set; }
    }

    public class GoogleConfigurationModel
    {
        public string Client_ID { get; set; }
    }
}
