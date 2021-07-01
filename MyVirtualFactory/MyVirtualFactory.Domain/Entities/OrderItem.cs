using System;
using System.Collections.Generic;
using System.Text;
using MyVirtualFactory.Domain.Common;

namespace MyVirtualFactory.Domain.Entities
{
    public class OrderItem : BaseEntity
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public double Amount { get; set; }
    }
}
