using ECommerce.Application.Abstractions;
using ECommerce.Application.Dtos.ProductDtos;
using ECommerce.Application.Repositories.IProductRepositories;
using ECommerce.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductWriteRepository _productWriteRepository;
        private readonly IProductReadRepository _productReadRepository;
        public ProductController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetProduct()
        {
            return Ok(await _productReadRepository.GetAll());
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
        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            var model=await _productReadRepository.GetByIdAsync(id, true);
            _productWriteRepository.Remove(model);
            await _productWriteRepository.SaveAsync();
            return Ok();
        }
    }
}
