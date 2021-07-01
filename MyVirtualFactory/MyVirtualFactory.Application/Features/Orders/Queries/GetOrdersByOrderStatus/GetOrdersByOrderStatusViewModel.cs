using System;
using System.Collections.Generic;
using System.Text;
using MyVirtualFactory.Domain.Entities;
using MyVirtualFactory.Domain.Enums;

namespace MyVirtualFactory.Application.Features.Orders.Queries.GetOrdersByOrderStatus
{
    public class GetOrdersByOrderStatusViewModel
    {
        public DateTime OrderDate { get; set; }
        public DateTime OrderDeadLineDate { get; set; }
   //     public List<Product> OrderProducts { get; set; }
    }
}
