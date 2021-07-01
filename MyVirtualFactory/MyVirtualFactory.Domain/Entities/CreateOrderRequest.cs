using System;
using System.Collections.Generic;
using System.Text;

namespace MyVirtualFactory.Domain.Entities
{
    public class CreateOrderRequest
    {
        public int ProductId { get; set; }
        public int Amount { get; set; }
    }
}
