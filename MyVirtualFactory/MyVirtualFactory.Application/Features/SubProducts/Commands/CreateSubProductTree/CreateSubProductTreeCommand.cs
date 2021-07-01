using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using MyVirtualFactory.Application.Interfaces.Repositories;
using MyVirtualFactory.Application.Wrappers;
using MyVirtualFactory.Domain.Entities;
using MyVirtualFactory.Domain.Enums;

namespace MyVirtualFactory.Application.Features.Products.Commands.CreateProduct
{
    public partial class CreateSubProductTreeCommand : IRequest<Response<int>>
    {
        public double ProduceAmount { get; set; }
        public int SubProductId { get; set; }
        public int ProductId { get; set; }
    }
    public class CreateSubProductTreeCommandHandler : IRequestHandler<CreateSubProductTreeCommand, Response<int>>
    {
        private readonly IProductRepositoryAsync _productRepository;
        private readonly ISubProductTreeRepositoryAsync _subProductRepository;
        private readonly IMapper _mapper;
        public CreateSubProductTreeCommandHandler(ISubProductTreeRepositoryAsync subProductRepository,IProductRepositoryAsync productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _subProductRepository = subProductRepository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateSubProductTreeCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.ProductId);

            var subProduct = await _productRepository.GetByIdAsync(request.SubProductId);
            var amount = request.ProduceAmount;


            SubProductTree subProductTree = new SubProductTree
            {
                ProductId = product.Id,
                SubProductId=subProduct.Id,
                ProduceAmount = amount
            };
            await _subProductRepository.AddAsync(subProductTree);

            return new Response<int>(subProductTree.Id);
        }
    }
}
