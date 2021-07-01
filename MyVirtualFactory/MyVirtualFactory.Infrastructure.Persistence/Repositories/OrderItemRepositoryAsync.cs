using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MyVirtualFactory.Application.Interfaces.Repositories;
using MyVirtualFactory.Domain.Entities;
using MyVirtualFactory.Infrastructure.Persistence.Contexts;
using MyVirtualFactory.Infrastructure.Persistence.Repository;
using MyVirtualFactory.Application.Features.OrderItems.Queries.GetOrderItemsByOrderId;
using System.Linq;
using MyVirtualFactory.Application.Features.Orders.Commands.ScheduleOrder;

namespace MyVirtualFactory.Infrastructure.Persistence.Repositories
{
    public class OrderItemRepositoryAsync : GenericRepositoryAsync<OrderItem>, IOrderItemRepositoryAsync
    {
        private readonly DbSet<OrderItem> _orderItems;

        public OrderItemRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _orderItems = dbContext.Set<OrderItem>();
        }

        public async Task<List<GetOrderItemsByOrderIdViewModel>> GetItemsByOrderId(int orderId)
        {
            var result = await _orderItems
                .Include(u=>u.Product)
                .Where(x => x.OrderId == orderId)
               .Select(y=> new GetOrderItemsByOrderIdViewModel
               {
                   Name = y.Product.Name,
                   Amount = y.Amount,
                   Id = y.Product.Id
               })
                .ToListAsync();
            return result;
        }

        public async Task<List<ScheduleOrderViewModel>> GetProductsWithOrderAmountByOrderId(int orderId)
        {
            var result = await _orderItems
                  .Include(t => t.Product)
                  .Where(t => t.OrderId == orderId)
                 .Select(t => new ScheduleOrderViewModel
                 {
                     ProductOrderAmount = t.Amount,
                     Name = t.Product.Name,
                     ProductType = t.Product.ProductType,
                     ProductId = t.Product.Id,
                     StockOfProduct = t.Product.AmountOfProduct

                 })
                  .ToListAsync();
            return result;
        }
    }
}
