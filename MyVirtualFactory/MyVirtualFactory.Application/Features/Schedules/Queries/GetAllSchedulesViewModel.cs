using System;
using System.Collections.Generic;
using System.Text;
using MyVirtualFactory.Domain.Entities;
using MyVirtualFactory.Domain.Enums;

namespace MyVirtualFactory.Application.Features.Schedules.Queries
{
    public class GetAllSchedulesViewModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int WorkCenterId { get; set; }
        public string ProductName { get; set; }
        public string WorkCenterName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
