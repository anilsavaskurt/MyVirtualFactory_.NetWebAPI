using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using MyVirtualFactory.Application.Interfaces.Repositories;
using MyVirtualFactory.Application.Wrappers;
using MyVirtualFactory.Domain.Entities;
using MyVirtualFactory.Domain.Enums;

namespace MyVirtualFactory.Application.Features.Operations.Commands.CreateOperation
{
    public partial class CreateOperationCommand : IRequest<Response<int>>
    {
        public string OperationName { get; set; }
        public ProductType OperationProductType { get; set; }
    }
    public class CreateOperationCommandHandler : IRequestHandler<CreateOperationCommand, Response<int>>
    {
        private readonly IOperationRepositoryAsync _operationRepository;
        private readonly IMapper _mapper;

        public CreateOperationCommandHandler(IOperationRepositoryAsync operationRepository, IMapper mapper)
        {
            _operationRepository = operationRepository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateOperationCommand request, CancellationToken cancellationToken)
        {
            Operation operation = new Operation()
            {
                OperationName = request.OperationName,
                OperationProductType = request.OperationProductType
            };
            await _operationRepository.AddAsync(operation);
            return new Response<int>(operation.Id);
        }
    }
}
