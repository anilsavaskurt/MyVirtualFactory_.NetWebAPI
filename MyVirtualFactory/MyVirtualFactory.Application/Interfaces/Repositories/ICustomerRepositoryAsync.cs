using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MyVirtualFactory.Domain.Entities;

namespace MyVirtualFactory.Application.Interfaces.Repositories
{
    public interface ICustomerRepositoryAsync : IGenericRepositoryAsync<Customer>
    {
     Task<Customer> GetByIdIncludeAsync(int id);
     Task<int> GetCustomerIdByUserId(string id);
    }
}
