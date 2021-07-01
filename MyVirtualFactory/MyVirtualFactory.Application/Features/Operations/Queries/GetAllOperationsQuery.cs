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
    public class GetAllOperationsQuery : IRequest<Response<IEnumerable<GetAllOperationsViewModel>>>
    {
    }
    public class GetAllOperationsQueryHandler : IRequestHandler<GetAllOperationsQuery, Response<IEnumerable<GetAllOperationsViewModel>>>
    {
        private readonly IOperationRepositoryAsync _operationRepository;
        private readonly IMapper _mapper;
        public GetAllOperationsQueryHandler(IOperationRepositoryAsync operationRepository, IMapper mapper)
        {
            _operationRepository = operationRepository;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<GetAllOperationsViewModel>>> Handle(GetAllOperationsQuery request, CancellationToken cancellationToken)
        {

            var operations = await _operationRepository.GetAllAsync();
            var operationsViewModel = _mapper.Map<IEnumerable<GetAllOperationsViewModel>>(operations);
            return new Response<IEnumerable<GetAllOperationsViewModel>>(operationsViewModel);
        }

    }
}
