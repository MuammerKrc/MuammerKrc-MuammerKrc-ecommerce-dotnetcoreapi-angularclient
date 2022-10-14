using ECommerce.Application.Abstractions;
using ECommerce.Application.Dtos.ProductDtos;
using ECommerce.Application.Features.Commands.ProductCommands.CreateProduct;
using ECommerce.Application.Features.Commands.ProductCommands.RemoveProduct;
using ECommerce.Application.Features.Commands.ProductImageFileCommands.UploadProductImage;
using ECommerce.Application.Features.Queries.ProductQueries.GetAllProduct;
using ECommerce.Application.Repositories.IProductRepositories;
using ECommerce.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        readonly IMediator _mediator;
        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetProduct([FromQuery] ProductGetAllQueryRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] ProductCreateCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] ProductRemoveCommandRequest request)
        {
            var repsonse = await _mediator.Send(request);
            return Ok();
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Upload([FromQuery] UploadProductImageCommandRequest request)
        {
            request.Files = Request.Form.Files;
            UploadProductImageCommandResponse response = await _mediator.Send(request);
            return Ok();
        }
    }
}
