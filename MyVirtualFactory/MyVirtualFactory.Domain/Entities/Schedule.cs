using System;
using System.Collections.Generic;
using System.Text;
using MyVirtualFactory.Domain.Common;
using MyVirtualFactory.Domain.Enums;

namespace MyVirtualFactory.Domain.Entities
{
    public class Schedule : BaseEntity
    {
        public int ProductId { get; set; }
        public int WorkCenterId { get; set; }
        public string ProductName { get; set; }
        public string WorkCenterName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
