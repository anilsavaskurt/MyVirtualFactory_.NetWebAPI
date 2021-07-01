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
    public partial class CreateWorkCenterCommand : IRequest<Response<int>>
    {
        public string WorkCenterName { get; set; }
        public bool IsActive { get; set; }

    }
    public class CreateWorkCenterCommandHandler : IRequestHandler<CreateWorkCenterCommand, Response<int>>
    {
        private readonly IProductRepositoryAsync _productRepository;
        private readonly IWorkCenterRepositoryAsync _workCenterRepository;
        private readonly IMapper _mapper;
        public CreateWorkCenterCommandHandler(IWorkCenterRepositoryAsync workCenterRepository, IProductRepositoryAsync productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _workCenterRepository = workCenterRepository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateWorkCenterCommand request, CancellationToken cancellationToken)
        {
            WorkCenter workCenter = new WorkCenter()
            {
                IsActive = request.IsActive,
                WorkCenterName = request.WorkCenterName
            };
            await _workCenterRepository.AddAsync(workCenter);
            return new Response<int>(workCenter.Id);
        }
    }
}
