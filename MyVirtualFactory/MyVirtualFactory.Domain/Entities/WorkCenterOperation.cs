using System;
using System.Collections.Generic;
using System.Text;
using MyVirtualFactory.Domain.Common;
using MyVirtualFactory.Domain.Enums;

namespace MyVirtualFactory.Domain.Entities
{
    public class WorkCenterOperation : BaseEntity
    {
        public int WorkCenterId { get; set; }
        public WorkCenter WorkCenter { get; set; }
        public int OperationId { get; set; }
        public Operation Operation { get; set; }
        public double Speed { get; set; }
    }
}
