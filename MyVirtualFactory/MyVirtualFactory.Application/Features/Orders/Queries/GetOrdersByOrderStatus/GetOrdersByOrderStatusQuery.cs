using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MyVirtualFactory.Application.Filters;
using MyVirtualFactory.Application.Interfaces.Repositories;
using MyVirtualFactory.Application.Wrappers;
using MyVirtualFactory.Domain.Entities;
using MyVirtualFactory.Domain.Enums;

namespace MyVirtualFactory.Application.Features.Orders.Queries.GetOrdersByOrderStatus
{
    public class GetOrdersByOrderStatusQuery : IRequest<Response<List<GetOrdersByOrderStatusViewModel>>>
    {
        public OrderStatus OrderStatus{ get; set; }
    }
    public class GetOrdersByOrderStatusQueryHandler : IRequestHandler<GetOrdersByOrderStatusQuery, Response<List<GetOrdersByOrderStatusViewModel>>>
    {
        private readonly IProductRepositoryAsync _productRepository;
        private readonly IOrderRepositoryAsync _orderRepository;
        private readonly IMapper _mapper;
        public GetOrdersByOrderStatusQueryHandler(IOrderRepositoryAsync orderRepository,IProductRepositoryAsync productRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<Response<List<GetOrdersByOrderStatusViewModel>>> Handle(GetOrdersByOrderStatusQuery request, CancellationToken cancellationToken)
        {

            var viewModel = await _orderRepository.GetOrdersByStatus(request.OrderStatus);
           


            return new Response<List<GetOrdersByOrderStatusViewModel>>(viewModel);
        }
    }
}
