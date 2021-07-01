using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MyVirtualFactory.Domain.Entities;

namespace MyVirtualFactory.Application.Interfaces.Repositories
{
    public interface IProductRepositoryAsync : IGenericRepositoryAsync<Product>
    {
        Task<List<Product>> GetAllSalableProductAsync();
        // Task<bool> IsUniqueBarcodeAsync(string barcode);
    }
}
