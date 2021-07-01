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
    public class UserRepositoryAsync : GenericRepositoryAsync<User>, IUserRepositoryAsync
    {
        private readonly DbSet<User> _users;

        public UserRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _users = dbContext.Set<User>();
        }

    }
}
