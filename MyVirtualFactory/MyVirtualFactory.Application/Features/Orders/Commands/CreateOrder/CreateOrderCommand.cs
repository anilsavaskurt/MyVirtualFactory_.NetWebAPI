using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MyVirtualFactory.Application.Interfaces.Repositories;
using MyVirtualFactory.Application.Wrappers;
using MyVirtualFactory.Domain.Entities;

namespace MyVirtualFactory.Application.Features.Products.Commands.CreateProduct
{
    public partial class CreateOrderCommand : IRequest<Response<int>>
    {

        //public Dictionary<string,string> ProductIdAmount{ get; set; } // Hangi ürün miktarından ne kadar olduğu belirtmek için kullanılır. Dic<ürünId,Amount>

       public  List<CreateOrderRequest> Products { get; set; }
       public string CustomerId { get; set; }
       public DateTime OrderDeadLineDate { get; set; } // Sipariş ulaştırma son tarih

    }
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Response<int>>
    {
        private readonly IProductRepositoryAsync _productRepository;
        private readonly IOrderRepositoryAsync _orderRepository;
        private readonly IOrderItemRepositoryAsync _orderItemRepository;
        private readonly ICustomerRepositoryAsync _customerRepository;
        private readonly IMapper _mapper;
        public CreateOrderCommandHandler(ICustomerRepositoryAsync customerRepository,IOrderRepositoryAsync orderRepository, IOrderItemRepositoryAsync orderItemRepository, IProductRepositoryAsync productRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _orderItemRepository = orderItemRepository;
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            //Dictionary<productId, Amount>
            //Dictionary<string, string> productIdAmount = request.ProductIdAmount;

            // Authenticated custo mer çekilecek..
            //   var  customer1 = await _customerRepository.GetByIdAsync(1);
            var customerId = await _customerRepository.GetCustomerIdByUserId(request.CustomerId);
            //var customer1 = await _customerRepository.GetByIdIncludeAsync(customerId);
            Order order = new Order()
            {
                OrderDate = DateTime.Now,
                OrderDeadLineDate = request.OrderDeadLineDate,
                OrderStatus = Domain.Enums.OrderStatus.Created,
                CustomerId = customerId
            };

            await _orderRepository.AddAsync(order);

            foreach (var i in request.Products)
            {
                //int productId = Int16.Parse(i.Key);
                //int amount = int.Parse(i.Value);
                int productId = Convert.ToInt32(i.ProductId);
                int amount = Convert.ToInt32(i.Amount);

                Product product = await _productRepository.GetByIdAsync(productId);

                OrderItem orderItem = new OrderItem
                {
                    ProductId= product.Id,
                    Amount = amount,
                    OrderId = order.Id
                };
                await _orderItemRepository.AddAsync(orderItem);
            }


            // ORDER
            //  public DateTime OrderDate { get; set; }
            //public DateTime OrderDateLine { get; set; }
            //public Customer Customer { get; set; }


            // ORDERITEM
            //public Product Product { get; set; }
            //public Order Order { get; set; }
            //public double Amount { get; set; }

            // Authenticateduserdan hangi customer olduğu bilgisi çekilir,
            // Verilen bilgilerle ilgli kullanıcının siparişi oluşturulur 
            // ORderItem tablosuna hangi üründen ne kadar olduğu bilgisi girilir.


            //var product = _mapper.Map<Product>(request);
            //await _productRepository.AddAsync(product);
            return new Response<int>(order.Id);
        }
    }
}
