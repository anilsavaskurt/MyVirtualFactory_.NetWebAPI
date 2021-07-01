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

namespace MyVirtualFactory.Application.Features.Schedules.Queries
{
    public class GetAllSchedulesQuery : IRequest<Response<IEnumerable<GetAllSchedulesViewModel>>>
    {
    }
    public class GetAllSchedulesQueryHandler : IRequestHandler<GetAllSchedulesQuery, Response<IEnumerable<GetAllSchedulesViewModel>>>
    {
        private readonly IScheduleRepositoryAsync _scheduleRepositoryAsync;
        private readonly IMapper _mapper;
        public GetAllSchedulesQueryHandler(IScheduleRepositoryAsync scheduleRepositoryAsync, IMapper mapper)
        {
            _scheduleRepositoryAsync = scheduleRepositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<GetAllSchedulesViewModel>>> Handle(GetAllSchedulesQuery request, CancellationToken cancellationToken)
        {

            var schedules = await _scheduleRepositoryAsync.GetAllAsync();
            var schedulesViewModel = _mapper.Map<IEnumerable<GetAllSchedulesViewModel>>(schedules);
            return new Response<IEnumerable<GetAllSchedulesViewModel>>(schedulesViewModel);
        }
    }
}
