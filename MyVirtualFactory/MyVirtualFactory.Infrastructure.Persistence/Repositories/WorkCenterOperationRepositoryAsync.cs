using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MyVirtualFactory.Application.Interfaces.Repositories;
using MyVirtualFactory.Domain.Entities;
using MyVirtualFactory.Infrastructure.Persistence.Contexts;
using MyVirtualFactory.Infrastructure.Persistence.Repository;
using MyVirtualFactory.Domain.Enums;
using System.Linq;
using MyVirtualFactory.Application.Features.Orders.Commands.ScheduleOrder;

namespace MyVirtualFactory.Infrastructure.Persistence.Repositories
{
    public class WorkCenterOperationRepositoryAsync : GenericRepositoryAsync<WorkCenterOperation>, IWorkCenterOperationRepositoryAsync
    {
        private readonly DbSet<WorkCenterOperation> _workCenterOperations;

        public WorkCenterOperationRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _workCenterOperations = dbContext.Set<WorkCenterOperation>();
        }

        public async Task<List<ResponseScheduleViewModel>> GetWorkCentersByProductType(List<ScheduleOrderViewModel> products)
        {
            var workCenters = new List<ResponseScheduleViewModel>();
            foreach(var item in products)
            {
                var result = await _workCenterOperations.Include(t => t.Operation).Include(x => x.WorkCenter).Where(u => u.Operation.OperationProductType == item.ProductType).Select(t => new ResponseScheduleViewModel
                {
                    WorkCenterId = t.WorkCenter.Id,
                    WorkCenterIsActive = t.WorkCenter.IsActive,
                    WorkCenterName = t.WorkCenter.WorkCenterName,
                    ProductId = item.ProductId,
                    ProductType = item.ProductType,
                    ProductName = item.Name
                 }).ToListAsync();
                foreach(var res in result)
                    workCenters.Add(res);
            }

            return workCenters;
        }

    }
}
