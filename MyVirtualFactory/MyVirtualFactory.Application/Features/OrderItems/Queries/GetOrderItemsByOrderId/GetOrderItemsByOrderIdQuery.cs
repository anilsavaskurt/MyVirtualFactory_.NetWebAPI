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

namespace MyVirtualFactory.Application.Features.OrderItems.Queries.GetOrderItemsByOrderId
{
    public class GetOrderItemsByOrderIdQuery : IRequest<Response<List<GetOrderItemsByOrderIdViewModel>>>
    {
        public int OrderId { get; set; }
    }
    public class GetOrderItemsByOrderIdQueryHandler : IRequestHandler<GetOrderItemsByOrderIdQuery, Response<List<GetOrderItemsByOrderIdViewModel>>>
    {
        private readonly IOrderItemRepositoryAsync _orderItemRepository;
        private readonly IProductRepositoryAsync _productRepository;
        private readonly IMapper _mapper;
        public GetOrderItemsByOrderIdQueryHandler(IOrderItemRepositoryAsync orderItemRepository,IOrderRepositoryAsync orderRepository,IProductRepositoryAsync productRepository, IMapper mapper)
        {
            _orderItemRepository = orderItemRepository;
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<Response<List<GetOrderItemsByOrderIdViewModel>>> Handle(GetOrderItemsByOrderIdQuery request, CancellationToken cancellationToken)
        {

            List<GetOrderItemsByOrderIdViewModel> viewModel = new List<GetOrderItemsByOrderIdViewModel>();
            viewModel = await _orderItemRepository.GetItemsByOrderId(request.OrderId);
            return new Response<List<GetOrderItemsByOrderIdViewModel>>(viewModel);
        }
    }
}
