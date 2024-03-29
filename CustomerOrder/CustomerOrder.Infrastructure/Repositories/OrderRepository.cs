﻿using CustomerOrder.Application.Common.Interfaces.Repositories;
using CustomerOrder.Domain.Entities;
using CustomerOrder.Infrastructure.Common;

namespace CustomerOrder.Infrastructure.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(CustomerOrderDbContext dbContext) : base(dbContext){}

        public IQueryable<Order> GetAll()
        {
            return _dbContext.Set<Order>();
        }
    }
}
