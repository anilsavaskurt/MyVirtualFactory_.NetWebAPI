using System;
using System.Collections.Generic;
using System.Text;
using MyVirtualFactory.Domain.Common;
using MyVirtualFactory.Domain.Enums;

namespace MyVirtualFactory.Domain.Entities
{
    public class Operation : BaseEntity
    {
        public string OperationName { get; set; }
        public ProductType OperationProductType { get; set; }

        public virtual ICollection<WorkCenterOperation> WorkCenterOperations { get; set; }

        public Operation()
        {
            WorkCenterOperations = new List<WorkCenterOperation>();
        }
    }
}
