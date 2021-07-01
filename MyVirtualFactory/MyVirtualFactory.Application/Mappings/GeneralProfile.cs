using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using MyVirtualFactory.Application.Features.Products.Commands.CreateProduct;
using MyVirtualFactory.Application.Features.Products.Queries.GetAllProducts;
using MyVirtualFactory.Application.Features.WorkCenters.Queries.GetAllWorkCenters;
using MyVirtualFactory.Domain.Entities;
using MyVirtualFactory.Application.Features.Orders.Queries.GetAllOrders;
using MyVirtualFactory.Application.Features.Schedules.Queries;

namespace MyVirtualFactory.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<Product, GetAllProductsViewModel>().ReverseMap();
            CreateMap<CreateProductCommand, Product>();

            // WorkCenters
            CreateMap<WorkCenter, GetAllWorkCentersViewModel>().ReverseMap();

            //ORDERS
            CreateMap<Order, GetAllOrdersViewModel>().ReverseMap();

            //OPERATIONS
            CreateMap<Operation, GetAllOperationsViewModel>().ReverseMap();

            //SCHEDULES
            CreateMap<Schedule, GetAllSchedulesViewModel>().ReverseMap();
        }
    }
}
