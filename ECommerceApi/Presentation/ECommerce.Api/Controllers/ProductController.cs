using ECommerce.Application.Abstractions;
using ECommerce.Application.Dtos.ProductDtos;
using ECommerce.Application.Features.Commands.ProductImageFileCommands.UploadProductImage;
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
        private readonly IProductWriteRepository _productWriteRepository;
        private readonly IProductReadRepository _productReadRepository;
        readonly IMediator _mediator;
        public ProductController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository, IMediator mediator)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetProduct(int page = 0, int size = 10)
        {
            var response = await _productReadRepository.GetWhere(i => true).Skip(page * size).Take(size).ToListAsync();
            var totalCount = _productReadRepository.GetWhere(i => true).Count();
            return Ok(new ProductPageListResultDto()
            {
                Result = response,
                TotalCount = totalCount
            });
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(dto);
            _productWriteRepository.Add(new Product()
            {
                Name = dto.Name,
                Price = dto.Price,
                Stock = dto.Stock
            });
            await _productWriteRepository.SaveAsync();
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            var model = await _productReadRepository.GetByIdAsync(id, true);
            _productWriteRepository.Remove(model);
            await _productWriteRepository.SaveAsync();
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
