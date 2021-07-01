using System;
using System.Collections.Generic;
using System.Text;
using MyVirtualFactory.Domain.Enums;

namespace MyVirtualFactory.Application.Features.Orders.Commands.ScheduleOrder
{
    public class ScheduleOrderViewModel
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public ProductType ProductType { get; set; }
        public int StockOfProduct { get; set; }
        public double ProductOrderAmount { get; set; }
    }
}
