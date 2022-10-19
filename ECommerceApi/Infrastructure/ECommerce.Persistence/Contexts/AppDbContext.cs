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
        public AppDbContext(DbContextOptions options) : base(options)
        { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }
        public DbSet<ProductImageFile> ProductImageFiles { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .HasKey(b => b.Id);

            modelBuilder.Entity<Order>()
                .HasIndex(o => o.OrderCode)
                .IsUnique();

            modelBuilder.Entity<Basket>()
                .HasOne(b => b.Order)
                .WithOne(o => o.Basket)
                .HasForeignKey<Order>(b => b.Id);
            base.OnModelCreating(modelBuilder);
        }

        //public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        //{
        //    //ChangeTracker : Entityler üzerinden yapılan değişiklerin ya da yeni eklenen verinin yakalanmasını sağlayan propertydir. Update operasyonlarında Track edilen verileri yakalayıp elde etmemizi sağlar.

        //    var datas = ChangeTracker
        //        .Entries<BaseEntity>();

        //    foreach (var data in datas)
        //    {
        //        _ = data.State switch
        //        {
        //            EntityState.Added => data.Entity.CreatedDate = DateTime.UtcNow,
        //            EntityState.Modified => data.Entity.UpdatedDate = DateTime.UtcNow,
        //            _ => DateTime.UtcNow
        //        };
        //    }

        //    return await base.SaveChangesAsync(cancellationToken);
        //}
    }

}
