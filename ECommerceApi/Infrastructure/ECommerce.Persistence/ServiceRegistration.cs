using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Application.Abstractions;
using ECommerce.Application.Abstractions.Services;
using ECommerce.Application.Abstractions.Services.IAuthServices;
using ECommerce.Application.Repositories;
using ECommerce.Application.Repositories.IBasketItemRepositories;
using ECommerce.Application.Repositories.IBasketRepositories;
using ECommerce.Application.Repositories.IOrderRepositories;
using ECommerce.Application.Repositories.IProductImageFileRepositories;
using ECommerce.Application.Repositories.IProductRepositories;
using ECommerce.Domain.Entities.Identity;
using ECommerce.Persistence.Contexts;
using ECommerce.Persistence.Repositories;
using ECommerce.Persistence.Repositories.BasketItemRepository;
using ECommerce.Persistence.Repositories.BasketRepository;
using ECommerce.Persistence.Repositories.OrderRepository;
using ECommerce.Persistence.Repositories.ProductImageFileRepositories;
using ECommerce.Persistence.Repositories.ProductRepositories;
using ECommerce.Persistence.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServiceRegistration(this IServiceCollection service)
        {
            service.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseSqlServer(GetAppSettings.ConnectionString,
                    opt =>
                    {
                        opt.MigrationsAssembly("ECommerce.Persistence");
                    });
            });
            service.AddIdentity<AppUser, AppRole>(opt =>
            {
                opt.User.RequireUniqueEmail = true;

                opt.Password.RequireDigit = false;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequiredLength = 5;
                opt.Password.RequiredUniqueChars = 3;

            }).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();


            //repositories
            service.AddScoped(typeof(IReadRepository<,>), typeof(ReadRepository<,>));
            service.AddScoped(typeof(IWriteRepository<,>), typeof(WriteRepository<,>));
            service.AddScoped<IProductReadRepository, ProductReadRepository>();
            service.AddScoped<IProductWriteRepository, ProductWriteRepository>();
            service.AddScoped<IProductImageFileReadRepository, ProductImageFileReadRepository>();
            service.AddScoped<IProductImageFileWriteRepository, ProductImageFileWriteRepository>();
            service.AddScoped<IOrderReadRepository, OrderReadRepository>();
            service.AddScoped<IOrderWriteRepository, OrderWriteRepository>();
            service.AddScoped<IBasketItemReadRepository, BasketItemReadRepository>();
            service.AddScoped<IBasketItemWriteRepository, BasketItemWriteRepository>();
            service.AddScoped<IBasketReadRepository, BasketReadRepository>();
            service.AddScoped<IBasketWriteRepository, BasketWriteRepository>();

            //service
            service.AddScoped<IUserService, UserService>();
            service.AddScoped<IAuthService, AuthService>();
            service.AddScoped<IBasketService, BasketService>();
            service.AddScoped<IOrderService, OrderService>();

        }
    }
}
