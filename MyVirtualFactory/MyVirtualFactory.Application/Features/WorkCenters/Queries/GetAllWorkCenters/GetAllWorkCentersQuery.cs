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

namespace MyVirtualFactory.Application.Features.WorkCenters.Queries.GetAllWorkCenters
{
    public class GetAllWorkCentersQuery : IRequest<Response<IEnumerable<GetAllWorkCentersViewModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
    public class GetAllWorkCentersQueryHandler : IRequestHandler<GetAllWorkCentersQuery, Response<IEnumerable<GetAllWorkCentersViewModel>>>
    {
        private readonly IWorkCenterRepositoryAsync _workCenterRepository;
        private readonly IMapper _mapper;
        public GetAllWorkCentersQueryHandler(IWorkCenterRepositoryAsync workCenterRepository, IMapper mapper)
        {
            _workCenterRepository = workCenterRepository;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<GetAllWorkCentersViewModel>>> Handle(GetAllWorkCentersQuery request, CancellationToken cancellationToken)
        {
            // Work Center Work Center Operation ile birlikte database'den çekilecek

            var workCenters = await _workCenterRepository.GetAllAsync();
            var workCentersViewModel = _mapper.Map<IEnumerable<GetAllWorkCentersViewModel>>(workCenters);
            return new Response<IEnumerable<GetAllWorkCentersViewModel>>(workCentersViewModel);
        }
    }
}
