﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MyVirtualFactory.Application.Features.OrderItems.Queries.GetOrderItemsByOrderId;
using MyVirtualFactory.Application.Features.Orders.Commands.ScheduleOrder;
using MyVirtualFactory.Domain.Entities;

namespace MyVirtualFactory.Application.Interfaces.Repositories
{
    public interface IOrderItemRepositoryAsync : IGenericRepositoryAsync<OrderItem>
    {
        Task<List<GetOrderItemsByOrderIdViewModel>> GetItemsByOrderId(int orderId);
        Task<List<ScheduleOrderViewModel>> GetProductsWithOrderAmountByOrderId(int orderId);
    }
}
