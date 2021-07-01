using System;
using System.Collections.Generic;
using System.Text;
using MyVirtualFactory.Domain.Enums;

namespace MyVirtualFactory.Application.Features.Orders.Commands.ScheduleOrder
{
    public class ResponseScheduleViewModel
    {
        public int ProductId { get; set; }
        public int WorkCenterId { get; set; }
        public string ProductName { get; set; }
        public ProductType ProductType { get; set; }
        public string WorkCenterName { get; set; }
        public bool WorkCenterIsActive { get; set; }
    }
}
