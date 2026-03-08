using AmassTest.Application.Features.Products.DeleteProduct;
using AmassTest.Application.Interfaces;
using AmassTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;

namespace AmassTest.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private static readonly List<Product> _products = new();

        public Task AddAsync(Product product)
        {
            product.Id = _products.Any() ? _products.Max(x => x.Id) + 1 : 1;
            _products.Add(product);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(int id)
        {
            var p = _products.FirstOrDefault(x => x.Id == id);
            if (p != null)
                _products.Remove(p);

            return Task.CompletedTask;
        }

        public Task<List<Product>> GetAllAsync()
        {
            return Task.FromResult(_products);
        }
    }
}
