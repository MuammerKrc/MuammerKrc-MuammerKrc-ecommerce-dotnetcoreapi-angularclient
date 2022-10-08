using ECommerce.Application.Abstractions;
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
            _productWriteRepository.AddRange(
                new List<Product>()
                {
                    new(){ Name = "Product 1",Price = 100,Stock = 10},
                    new(){ Name = "Product 2",Price = 150,Stock = 15},
                    new(){ Name = "Product 3",Price = 200,Stock = 20},
                    new(){ Name = "Product 4",Price = 150,Stock = 25},
                });
            await _productWriteRepository.SaveAsync();
            return Ok();
        }
    }
}
