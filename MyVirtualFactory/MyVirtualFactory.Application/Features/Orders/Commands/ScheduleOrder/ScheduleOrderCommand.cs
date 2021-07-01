using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MyVirtualFactory.Application.Interfaces.Repositories;
using MyVirtualFactory.Application.Wrappers;
using MyVirtualFactory.Domain.Entities;
using System.Linq;
using MyVirtualFactory.Domain.Enums;
using MyVirtualFactory.Application.Features.Orders.Commands.ScheduleOrder;

namespace MyVirtualFactory.Application.Features.Products.Commands.ScheduleOrder
{
    public partial class ScheduleOrderCommand : IRequest<Response<List<ResponseScheduleViewModel>>>
    {
        public int OrderId { get; set; }
    }
    public class ScheduleOrderCommandHandler : IRequestHandler<ScheduleOrderCommand, Response<List<ResponseScheduleViewModel>>>
    {
        private readonly IProductRepositoryAsync _productRepository;
        private readonly IOrderRepositoryAsync _orderRepository;
        private readonly IOrderItemRepositoryAsync _orderItemRepository;
        private readonly ISubProductTreeRepositoryAsync _subProductRepository;
        private readonly ICustomerRepositoryAsync _customerRepository;
        private readonly IOperationRepositoryAsync _operationRepository;
        private readonly IWorkCenterOperationRepositoryAsync _workCenterOperationRepository;
        private readonly IMapper _mapper;
        public ScheduleOrderCommandHandler(IWorkCenterOperationRepositoryAsync workCenterOperationRepository, IOperationRepositoryAsync operationRepository, ISubProductTreeRepositoryAsync subProductRepository, ICustomerRepositoryAsync customerRepository, IOrderRepositoryAsync orderRepository, IOrderItemRepositoryAsync orderItemRepository, IProductRepositoryAsync productRepository, IMapper mapper)
        {
            _workCenterOperationRepository = workCenterOperationRepository;
            _operationRepository = operationRepository;
            _subProductRepository = subProductRepository;
            _customerRepository = customerRepository;
            _orderItemRepository = orderItemRepository;
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<Response<List<ResponseScheduleViewModel>>> Handle(ScheduleOrderCommand request, CancellationToken cancellationToken)
        {

            List<ScheduleOrderViewModel> productCanProduce = new List<ScheduleOrderViewModel>();
            var products = await _productRepository.GetAllAsync();
            var orderProducts = await _orderItemRepository.GetProductsWithOrderAmountByOrderId(request.OrderId);
            var subProducts = await _subProductRepository.GetAllIncludeProduct();

            foreach (var item in orderProducts)
            {
                var subProdcutsInfo = subProducts.Where(t => t.ProductId == item.ProductId).Select(i => new { i.SubProductId, i.ProduceAmount }).ToList();

                if (subProdcutsInfo.Count() == 1)
                {
                    var stockAmountOfProduct = products.Where(t => t.Id == subProdcutsInfo[0].SubProductId).Select(t => t.AmountOfProduct).FirstOrDefault();
                    if (subProdcutsInfo[0].ProduceAmount < stockAmountOfProduct)
                    {
                        productCanProduce.Add(item);
                    }
                }

                if (subProdcutsInfo.Count() > 1)
                {
                    foreach (var sp in subProdcutsInfo)
                    {
                        var stockAmountOfProduct = products.Where(t => t.Id == sp.SubProductId).Select(t => t.AmountOfProduct).FirstOrDefault();
                        if (sp.ProduceAmount < stockAmountOfProduct && !productCanProduce.Contains(item))
                        {
                            productCanProduce.Add(item);
                        }
                    }
                }
            }

              var result = await _workCenterOperationRepository.GetWorkCentersByProductType(productCanProduce);

            return new Response<List<ResponseScheduleViewModel>>(result);
        }
    }
}
