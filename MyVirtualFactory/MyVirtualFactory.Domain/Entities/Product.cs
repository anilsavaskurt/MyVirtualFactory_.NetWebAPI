using System;
using System.Collections.Generic;
using System.Text;
using MyVirtualFactory.Domain.Common;
using MyVirtualFactory.Domain.Enums;

namespace MyVirtualFactory.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public ProductType ProductType { get; set; }
        public bool IsSalable { get; set; }
        public int AmountOfProduct { get; set; }


        public virtual ICollection<OrderItem> OrderItems { get; set; }
        public virtual ICollection<SubProductTree> SubProductTrees{ get; set; } //SubProductTablosu SubProductİçin
         public Product()
        {
            OrderItems = new List<OrderItem>();
            SubProductTrees = new List<SubProductTree>();
          }
    }
}
