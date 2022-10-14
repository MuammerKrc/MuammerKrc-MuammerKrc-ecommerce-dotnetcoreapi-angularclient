using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using File = ECommerce.Domain.Entities.File;

namespace ECommerce.Persistence.Contexts
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<ProductImageFile> ProductImageFiles { get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }

}
