using System;
using System.Collections.Generic;
using System.Text;

namespace MyVirtualFactory.Application.Features.WorkCenters.Queries.GetAllWorkCenters
{
    public class GetAllWorkCentersViewModel
    {
        public int Id{ get; set; }
        public string WorkCenterName { get; set; }
        public bool IsActive { get; set; }
    }
}
