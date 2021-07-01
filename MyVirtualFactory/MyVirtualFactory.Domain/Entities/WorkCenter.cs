using System;
using System.Collections.Generic;
using System.Text;
using MyVirtualFactory.Domain.Common;
using MyVirtualFactory.Domain.Enums;

namespace MyVirtualFactory.Domain.Entities
{
    public class WorkCenter : BaseEntity
    {
        public string WorkCenterName { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<WorkCenterOperation> WorkCenterOperations { get; set; }

        public WorkCenter()
        {
            WorkCenterOperations = new List<WorkCenterOperation>();
        }
    }
}
