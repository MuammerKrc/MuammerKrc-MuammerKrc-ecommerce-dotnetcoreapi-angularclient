﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Domain.Entities;

namespace ECommerce.Application.Repositories.IBasketRepositories
{
    public interface IBasketReadRepository : IReadRepository<Basket, Guid>
    {
    }
}
