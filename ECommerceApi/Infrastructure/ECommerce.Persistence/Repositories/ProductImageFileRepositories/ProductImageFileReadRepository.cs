using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Application.Repositories.IProductImageFileRepositories;
using ECommerce.Persistence.Contexts;

namespace ECommerce.Persistence.Repositories.ProductImageFileRepositories
{
    public class ProductImageFileReadRepository:ReadRepository<Domain.Entities.ProductImageFile,Guid>,IProductImageFileReadRepository
    {
        public ProductImageFileReadRepository(AppDbContext context) : base(context)
        {
        }
    }
}
