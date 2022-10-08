using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Application.Abstractions;
using ECommerce.Domain.Entities;

namespace ECommerce.Persistence.Concretes
{
    public class ProductService : IProductService
    {
        public List<Product> GetProducts()
        {
            return new List<Product>()
            {
                new Product() { Name = "Deneme1", Price = 2350, Stock = 12 },
                new Product() { Name = "Deneme2", Price = 2350, Stock = 12 },
            };
        }
    }
}
