using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MyVirtualFactory.Application.Features.Orders.Queries.GetCustomersOrders;
using MyVirtualFactory.Application.Features.Orders.Queries.GetOrdersByOrderStatus;
using MyVirtualFactory.Domain.Entities;
using MyVirtualFactory.Domain.Enums;

namespace MyVirtualFactory.Application.Interfaces.Repositories
{
    public interface IOrderRepositoryAsync : IGenericRepositoryAsync<Order>
    {
        Task<List<GetOrdersByOrderStatusViewModel>> GetOrdersByStatus(OrderStatus orderStatus);
        Task<List<GetCustomersOrdersViewModel>> GetCustomersOrders(int customerId);
    }
}
