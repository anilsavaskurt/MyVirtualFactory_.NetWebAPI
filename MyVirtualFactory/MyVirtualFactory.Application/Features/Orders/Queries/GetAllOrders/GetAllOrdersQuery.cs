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

namespace MyVirtualFactory.Application.Features.Orders.Queries.GetAllOrders
{
    public class GetAllOrdersQuery : IRequest<Response<IEnumerable<GetAllOrdersViewModel>>>
    {
    }
    public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery, Response<IEnumerable<GetAllOrdersViewModel>>>
    {
        private readonly IProductRepositoryAsync _productRepository;
        private readonly IOrderRepositoryAsync _orderRepository;
        private readonly IMapper _mapper;
        public GetAllOrdersQueryHandler(IOrderRepositoryAsync orderRepository,IProductRepositoryAsync productRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<GetAllOrdersViewModel>>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {

            var orders = await _orderRepository.GetAllAsync();
            var ordersViewModel = _mapper.Map<IEnumerable<GetAllOrdersViewModel>>(orders);
            return new Response<IEnumerable<GetAllOrdersViewModel>>(ordersViewModel);
        }
    }
}
