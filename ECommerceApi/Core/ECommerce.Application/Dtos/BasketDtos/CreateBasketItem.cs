using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Dtos.BasketDtos
{
    public class CreateBasketItem
    {
        public string ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
