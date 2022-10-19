using ECommerce.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Domain.Entities.Common;

namespace ECommerce.Domain.Entities
{
    public class Basket : BaseEntity<Guid>
    {
        [ForeignKey("User")]
        public string UserId { get; set; }
        public AppUser User { get; set; }
        public Order Order { get; set; }
        public ICollection<BasketItem> BasketItems { get; set; }
    }
}
