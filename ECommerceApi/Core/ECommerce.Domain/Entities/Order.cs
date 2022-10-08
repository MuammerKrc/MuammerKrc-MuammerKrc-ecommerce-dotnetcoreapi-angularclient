using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Domain.Entities.Common;

namespace ECommerce.Domain.Entities
{
    public class Order : BaseEntity<Guid>
    {
        public string Description { get; set; }
        public string Address { get; set; }
        public string OrderCode { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
