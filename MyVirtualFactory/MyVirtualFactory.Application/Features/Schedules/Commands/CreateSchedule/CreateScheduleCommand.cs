using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using MyVirtualFactory.Application.Interfaces.Repositories;
using MyVirtualFactory.Application.Wrappers;
using MyVirtualFactory.Domain.Entities;
using MyVirtualFactory.Domain.Enums;
using System;

namespace MyVirtualFactory.Application.Features.Schedules.Commands.CreateSchedule
{
    public partial class CreateScheduleCommand : IRequest<Response<int>>
    {
        public int ProductId { get; set; }
        public int WorkCenterId { get; set; }
        public string ProductName { get; set; }
        public string WorkCenterName { get; set; }
        public DateTime EndDate { get; set; }
    }
    public class CreateScheduleCommandHandler : IRequestHandler<CreateScheduleCommand, Response<int>>
    {
        private readonly IScheduleRepositoryAsync _scheduleRepositoryAsync;
        private readonly IMapper _mapper;

        public CreateScheduleCommandHandler(IScheduleRepositoryAsync scheduleRepositoryAsync, IMapper mapper)
        {
            _scheduleRepositoryAsync = scheduleRepositoryAsync;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateScheduleCommand request, CancellationToken cancellationToken)
        {
            Schedule schedule = new Schedule()
            {
                ProductId = request.ProductId,
                ProductName = request.ProductName,
                WorkCenterId = request.WorkCenterId,
                WorkCenterName = request.WorkCenterName,
                StartDate = DateTime.Now,
                EndDate = request.EndDate
            };
            await _scheduleRepositoryAsync.AddAsync(schedule);
            return new Response<int>(schedule.Id);
        }
    }
}
