using System;
using System.Collections.Generic;
using System.Text;
using MyVirtualFactory.Domain.Common;
using MyVirtualFactory.Domain.Enums;

namespace MyVirtualFactory.Domain.Entities
{
    public class Order : BaseEntity
    {
        public DateTime OrderDate { get; set; }
        public DateTime OrderDeadLineDate { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public virtual ICollection<OrderItem> OrderItems{ get; set; }

        public Order()
        {
            OrderItems = new List<OrderItem>();
        }
    }
}
