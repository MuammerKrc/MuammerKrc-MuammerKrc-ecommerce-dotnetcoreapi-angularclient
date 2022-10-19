using ECommerce.Application.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace ECommerce.Application.Features.Commands.BasketCommands.AddBasketItem
{
    public class AddBasketItemCommandHandler : IRequestHandler<AddBasketItemCommandRequest, AddBasketItemCommandResponse>
    {
        readonly IBasketService _basketService;

        public AddBasketItemCommandHandler(IBasketService basketService)
        {
            _basketService = basketService;
        }


        public async Task<AddBasketItemCommandResponse> Handle(AddBasketItemCommandRequest request, CancellationToken cancellationToken)
        {
            await _basketService.AddItemToBasketAsync(new()
            {
                ProductId = request.ProductId,
                Quantity = request.Quantity
            });

            return new();
        }
    }
}
