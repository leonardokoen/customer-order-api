﻿using CustomerOrder.Application.Common.Interfaces.GenericRepository;
using CustomerOrder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrder.Application.Common.Interfaces.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
       Product? GetProductByName(string productNames);
    }
}
