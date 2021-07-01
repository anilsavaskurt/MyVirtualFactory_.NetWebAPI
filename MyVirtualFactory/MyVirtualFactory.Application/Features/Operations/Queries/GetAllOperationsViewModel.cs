using System;
using System.Collections.Generic;
using System.Text;
using MyVirtualFactory.Domain.Entities;
using MyVirtualFactory.Domain.Enums;

namespace MyVirtualFactory.Application.Features.Orders.Queries.GetAllOrders
{
    public class GetAllOperationsViewModel
    {
        public int Id { get; set; }
        public string OperationName { get; set; }
        public ProductType OperationProductType { get; set; }
    }
}
