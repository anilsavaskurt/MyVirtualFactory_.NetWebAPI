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
using MyVirtualFactory.Application.Interfaces;

namespace MyVirtualFactory.Application.Features.Orders.Queries.GetCustomersOrders
{
    public class GetCustomersOrdersQuery : IRequest<Response<List<GetCustomersOrdersViewModel>>>
    {
        public string CustomerId { get; set; }
    }
    public class GetCustomersOrdersQueryHandler : IRequestHandler<GetCustomersOrdersQuery, Response<List<GetCustomersOrdersViewModel>>>
    {
        private readonly IProductRepositoryAsync _productRepository;
        private readonly IOrderRepositoryAsync _orderRepository;
        private readonly ICustomerRepositoryAsync _customerRepositoryAsync;
        private readonly IMapper _mapper;
        public GetCustomersOrdersQueryHandler(IOrderRepositoryAsync orderRepository,IProductRepositoryAsync productRepository, IMapper mapper, ICustomerRepositoryAsync customerRepositoryAsync)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _mapper = mapper;
            _customerRepositoryAsync = customerRepositoryAsync;
        }

        public async Task<Response<List<GetCustomersOrdersViewModel>>> Handle(GetCustomersOrdersQuery request, CancellationToken cancellationToken)
        {
            // DAHA SONRA REGISTER YONTEMİNE GÖRE YAPILACAK....

            var customerId = await _customerRepositoryAsync.GetCustomerIdByUserId(request.CustomerId);

            var ordersViewModels = await _orderRepository.GetCustomersOrders(customerId);
           
            return new Response<List<GetCustomersOrdersViewModel>>(ordersViewModels);
        }
    }
}
