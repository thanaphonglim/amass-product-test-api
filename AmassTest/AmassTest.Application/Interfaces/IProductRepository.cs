using AmassTest.Application.Features.Products.DeleteProduct;
using AmassTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmassTest.Application.Interfaces
{
    public interface IProductRepository
    {
        Task AddAsync(Product product);
        Task DeleteAsync(int id);
        Task<List<Product>> GetAllAsync();
        Task<List<Product>> SearchByKeywordAsync(string keyword);

        Task<bool> ExistsByCodeAsync(string code);
    }
}
