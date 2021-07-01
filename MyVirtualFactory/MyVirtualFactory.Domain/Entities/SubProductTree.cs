using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using MyVirtualFactory.Domain.Common;
using MyVirtualFactory.Domain.Enums;

namespace MyVirtualFactory.Domain.Entities
{
    public class SubProductTree : BaseEntity
    {
        // tekrar bakılacak
        public double ProduceAmount { get; set; }
        public int SubProductId { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
