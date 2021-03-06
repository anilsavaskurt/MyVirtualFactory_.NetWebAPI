using System;
using System.Collections.Generic;
using System.Text;
using MyVirtualFactory.Domain.Entities;
using MyVirtualFactory.Domain.Enums;

namespace MyVirtualFactory.Application.Features.Orders.Queries.GetAllOrders
{
    public class GetAllOrdersViewModel
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime OrderDeadLineDate { get; set; }
        public OrderStatus OrderStatus { get; set; }
    }
}
