﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace ECommerce.Application.Features.Commands.BasketCommands.AddBasketItem
{
    public class AddBasketItemCommandRequest:IRequest<AddBasketItemCommandResponse>
    {
        public string ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
