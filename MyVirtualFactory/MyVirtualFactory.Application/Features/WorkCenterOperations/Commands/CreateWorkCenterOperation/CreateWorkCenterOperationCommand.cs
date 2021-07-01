using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using MyVirtualFactory.Application.Interfaces.Repositories;
using MyVirtualFactory.Application.Wrappers;
using MyVirtualFactory.Domain.Entities;
using MyVirtualFactory.Domain.Enums;

namespace MyVirtualFactory.Application.Features.WorkCenters.Commands.CreateWorkCenter
{
    public partial class CreateWorkCenterOperationCommand : IRequest<Response<int>>
    {
        public int WorkCenterId { get; set; }
        public int OperationId { get; set; }
        public double Speed { get; set; }
    }
    public class CreateWorkCenterOperationCommandHandler : IRequestHandler<CreateWorkCenterOperationCommand, Response<int>>
    {
        private readonly IProductRepositoryAsync _productRepository;
        private readonly IWorkCenterRepositoryAsync _workCenterRepository;
        private readonly IWorkCenterOperationRepositoryAsync _workCenterOperationRepository;
        private readonly IMapper _mapper;
        public CreateWorkCenterOperationCommandHandler(IWorkCenterOperationRepositoryAsync workCenterOperationRepository,IWorkCenterRepositoryAsync workCenterRepository, IProductRepositoryAsync productRepository, IMapper mapper)
        {
            _workCenterOperationRepository = workCenterOperationRepository;
            _productRepository = productRepository;
            _workCenterRepository = workCenterRepository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateWorkCenterOperationCommand request, CancellationToken cancellationToken)
        {
            WorkCenterOperation workCenterOperation = new WorkCenterOperation
            {
                OperationId = request.OperationId,
                WorkCenterId = request.WorkCenterId,
                Speed = 1
            };

            await _workCenterOperationRepository.AddAsync(workCenterOperation);
            return new Response<int>(workCenterOperation.Id);
        }
    }
}
