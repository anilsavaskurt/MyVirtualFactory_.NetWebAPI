using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyVirtualFactory.Application.Features.Orders.Queries.GetOrdersByOrderStatus;
using MyVirtualFactory.Application.Interfaces.Repositories;
using MyVirtualFactory.Domain.Entities;
using MyVirtualFactory.Domain.Enums;
using MyVirtualFactory.Infrastructure.Persistence.Contexts;
using MyVirtualFactory.Infrastructure.Persistence.Repository;
using MyVirtualFactory.Application.Features.Orders.Queries.GetCustomersOrders;

namespace MyVirtualFactory.Infrastructure.Persistence.Repositories
{
    public class OrderRepositoryAsync : GenericRepositoryAsync<Order>, IOrderRepositoryAsync
    {
        private readonly DbSet<Order> _orders;

        public OrderRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _orders = dbContext.Set<Order>();
        }

        public async Task<List<GetCustomersOrdersViewModel>> GetCustomersOrders(int customerId)
        {
            return await _orders.Where(t => t.CustomerId.Equals(customerId)).Select(t => new GetCustomersOrdersViewModel()
            {
                Id = t.Id,
                OrderDate = t.OrderDate,
                OrderDeadLineDate = t.OrderDeadLineDate,
                OrderStatus = t.OrderStatus
            }).ToListAsync();
        }

        public async Task<List<GetOrdersByOrderStatusViewModel>> GetOrdersByStatus(OrderStatus orderStatus)
        {
            // Orderın Productları getirilecek olursa OrderItem ve Product tablosundan getirilecek.

            return await _orders.Where(t => t.OrderStatus.Equals(orderStatus)).Select(t => new GetOrdersByOrderStatusViewModel()
            {
                OrderDate = t.OrderDate,
                OrderDeadLineDate = t.OrderDeadLineDate
            }).ToListAsync();
        }
    }
}
