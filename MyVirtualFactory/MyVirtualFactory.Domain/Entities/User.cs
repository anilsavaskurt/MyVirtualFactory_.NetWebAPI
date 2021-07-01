using System;
using System.Collections.Generic;
using System.Text;
using MyVirtualFactory.Domain.Common;

namespace MyVirtualFactory.Domain.Entities
{
    public class User : BaseEntity
    {
        public string StaffUserId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
    }
}
