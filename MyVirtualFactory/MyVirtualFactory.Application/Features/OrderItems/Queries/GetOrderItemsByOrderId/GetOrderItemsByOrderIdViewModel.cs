using System;
using System.Collections.Generic;
using System.Text;
using MyVirtualFactory.Domain.Entities;
using MyVirtualFactory.Domain.Enums;

namespace MyVirtualFactory.Application.Features.OrderItems.Queries.GetOrderItemsByOrderId
{
    public class GetOrderItemsByOrderIdViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Amount{ get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime OrderDeadLineDate { get; set; }
    }
}
