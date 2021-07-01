using System;
using System.Collections.Generic;
using System.Text;
using MyVirtualFactory.Domain.Common;

namespace MyVirtualFactory.Domain.Entities
{
    public class Customer : BaseEntity
    {
        public string CustomerUserId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public virtual ICollection<Order> Orders { get; set; }

        public Customer()
        {
            Orders = new List<Order>();
        }
    }
}
