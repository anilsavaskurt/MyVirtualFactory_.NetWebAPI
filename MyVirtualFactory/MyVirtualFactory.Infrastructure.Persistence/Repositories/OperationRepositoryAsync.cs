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
    public class OperationRepositoryAsync : GenericRepositoryAsync<Operation>, IOperationRepositoryAsync
    {
        private readonly DbSet<Operation> _operations;

        public OperationRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _operations = dbContext.Set<Operation>();
        }

    }
}
