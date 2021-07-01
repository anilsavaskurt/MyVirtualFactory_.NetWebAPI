using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MyVirtualFactory.Application.Interfaces.Repositories;
using MyVirtualFactory.Domain.Entities;
using MyVirtualFactory.Infrastructure.Persistence.Contexts;
using MyVirtualFactory.Infrastructure.Persistence.Repository;

namespace MyVirtualFactory.Infrastructure.Persistence.Repositories
{
    public class WorkCenterRepositoryAsync : GenericRepositoryAsync<WorkCenter>, IWorkCenterRepositoryAsync
    {
        private readonly DbSet<WorkCenter> _workCenters;

        public WorkCenterRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _workCenters = dbContext.Set<WorkCenter>();
        }

    }
}
