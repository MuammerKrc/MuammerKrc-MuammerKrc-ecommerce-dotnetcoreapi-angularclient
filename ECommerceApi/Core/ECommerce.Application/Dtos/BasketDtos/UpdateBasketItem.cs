﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Dtos.BasketDtos
{
    public class UpdateBasketItem
    {
        public Guid BasketItemId { get; set; }
        public int Quantity { get; set; }
    }
}
