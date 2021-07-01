using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MyVirtualFactory.Application.Features.Orders.Commands.ScheduleOrder;
using MyVirtualFactory.Domain.Entities;
using MyVirtualFactory.Domain.Enums;

namespace MyVirtualFactory.Application.Interfaces.Repositories
{
    public interface IWorkCenterOperationRepositoryAsync : IGenericRepositoryAsync<WorkCenterOperation>
    {
        Task<List<ResponseScheduleViewModel>> GetWorkCentersByProductType(List<ScheduleOrderViewModel> productTypes);
  
    }
}
