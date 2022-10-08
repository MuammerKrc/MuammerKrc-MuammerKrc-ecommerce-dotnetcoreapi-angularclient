﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Application.Abstractions;
using ECommerce.Application.Repositories;
using ECommerce.Application.Repositories.IProductRepositories;
using ECommerce.Domain.Entities.Identity;
using ECommerce.Persistence.Concretes;
using ECommerce.Persistence.Contexts;
using ECommerce.Persistence.Repositories;
using ECommerce.Persistence.Repositories.ProductRepositories;
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


            service.AddScoped(typeof(IReadRepository<,>), typeof(ReadRepository<,>));
            service.AddScoped(typeof(IWriteRepository<,>), typeof(WriteRepository<,>));

            service.AddScoped<IProductReadRepository, ProductReadRepository>();
            service.AddScoped<IProductWriteRepository, ProductWriteRepository>();

            service.AddScoped<IProductService, ProductService>();
        }
    }
}
