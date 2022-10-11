using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Application.Repositories.IProductImageFileRepositories;
using ECommerce.Persistence.Contexts;

namespace ECommerce.Persistence.Repositories.ProductImageFileRepositories
{
    public class ProductImageFileWriteRepository:WriteRepository<Domain.Entities.ProductImageFile,Guid>,IProductImageFileWriteRepository
    {
        public ProductImageFileWriteRepository(AppDbContext context) : base(context)
        {
        }
    }
}
