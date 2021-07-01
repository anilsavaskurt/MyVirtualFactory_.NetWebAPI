using System;
using System.Collections.Generic;
using System.Text;
using MyVirtualFactory.Domain.Enums;

namespace MyVirtualFactory.Application.Features.Products.Queries.GetAllProducts
{
    public class GetAllProductsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ProductType ProductType { get; set; }
        public bool IsSalable { get; set; }
        public int AmountOfProduct { get; set; }
    }
}
