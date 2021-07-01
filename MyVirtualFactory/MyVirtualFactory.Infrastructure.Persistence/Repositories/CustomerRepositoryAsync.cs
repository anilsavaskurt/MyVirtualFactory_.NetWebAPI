using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyVirtualFactory.Application.Interfaces.Repositories;
using MyVirtualFactory.Domain.Entities;
using MyVirtualFactory.Infrastructure.Persistence.Contexts;
using MyVirtualFactory.Infrastructure.Persistence.Repository;
using MyVirtualFactory.Application.Interfaces;

namespace MyVirtualFactory.Infrastructure.Persistence.Repositories
{
    public class CustomerRepositoryAsync : GenericRepositoryAsync<Customer>, ICustomerRepositoryAsync
    {
        private readonly DbSet<Customer> _customers;
        private readonly IAuthenticatedUserService _userService;



        public CustomerRepositoryAsync(ApplicationDbContext dbContext, IAuthenticatedUserService userService) : base(dbContext)
        {
            _customers = dbContext.Set<Customer>();
            _userService = userService;
        }

        public async Task<Customer> GetByIdIncludeAsync(int id)
        {
          
               var s = await _customers.Include(t => t.Orders).Where(t => t.Id == id).FirstOrDefaultAsync();
            return s;
        }

        public async Task<int> GetCustomerIdByUserId(string id)
        {
            return await _customers.Where(t => t.CustomerUserId == id).Select(u => u.Id).FirstOrDefaultAsync();
        }
    }
}
