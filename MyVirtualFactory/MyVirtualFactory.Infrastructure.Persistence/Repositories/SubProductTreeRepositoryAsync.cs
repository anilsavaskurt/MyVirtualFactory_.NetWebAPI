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
    public class SubProductTreeRepositoryAsync : GenericRepositoryAsync<SubProductTree>, ISubProductTreeRepositoryAsync
    {
        private readonly DbSet<SubProductTree> _subProducts;

        public SubProductTreeRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _subProducts = dbContext.Set<SubProductTree>();
        }

        public async Task<List<SubProductTree>> GetAllIncludeProduct()
        {
            return await _subProducts.Include(u => u.Product).ToListAsync();
        }
    }
}
