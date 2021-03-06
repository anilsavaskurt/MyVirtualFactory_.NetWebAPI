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
    public class ScheduleRepositoryAsync : GenericRepositoryAsync<Schedule>, IScheduleRepositoryAsync
    {
        private readonly DbSet<Schedule> _schedule;

        public ScheduleRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _schedule = dbContext.Set<Schedule>();
        }
    }
}
