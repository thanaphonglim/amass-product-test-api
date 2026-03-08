using AmassTest.Application.Common.Exceptions;
using AmassTest.Application.Common.Helpers;
using AmassTest.Application.Features.Products.DeleteProduct;
using AmassTest.Application.Interfaces;
using AmassTest.Domain.Entities;
using AmassTest.Infrastructure.Data.AppDbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;

namespace AmassTest.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;
        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Product product)
        {
            try
            {
                await _context.Products.AddAsync(product);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                if (DbExceptionHelper.IsUniqueConstraintViolation(ex))
                    throw new DuplicateProductCodeException();
                throw;
            }
        }

        public async Task DeleteAsync(int id)
        {
            var p = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (p != null)
            {
                _context.Products.Remove(p);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<List<Product>> SearchByKeywordAsync(string keyword)
        {
            keyword = keyword.Replace("-", "").ToLower();
            var result = await _context.Products
                .Where(p => p.ProductCode.ToLower().Contains(keyword))
                .ToListAsync();

            return result;
        }

        public async Task<bool> ExistsByCodeAsync(string code)
        {
            return await _context.Products.AnyAsync(p => p.ProductCode == code);
        }
    }
}
