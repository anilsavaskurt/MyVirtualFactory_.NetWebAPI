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

namespace MyVirtualFactory.Application.Features.Products.Queries.GetAllProducts
{
    public class GetAllProductsQuery : IRequest<Response<IEnumerable<GetAllProductsViewModel>>>
    {
        public bool IsSalable { get; set; }
    }
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, Response<IEnumerable<GetAllProductsViewModel>>>
    {
        private readonly IProductRepositoryAsync _productRepository;
        private readonly IMapper _mapper;
        public GetAllProductsQueryHandler(IProductRepositoryAsync productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<GetAllProductsViewModel>>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {

            IReadOnlyList<Product> products = new List<Product>();
            if (request.IsSalable)         
                products = await _productRepository.GetAllSalableProductAsync();

            if (!request.IsSalable)
                products = await _productRepository.GetAllAsync();

            var productViewModel = _mapper.Map<IEnumerable<GetAllProductsViewModel>>(products);
            return new Response<IEnumerable<GetAllProductsViewModel>>(productViewModel);
        }
    }
}
