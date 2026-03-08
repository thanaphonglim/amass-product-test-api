using AmassTest.Application.Common.Helpers;
using AmassTest.Application.Interfaces;
using AmassTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmassTest.Application.Features.Products.GetProducts
{
    public class GetProductsHandler
    {
        private readonly IProductRepository _repository;
        public GetProductsHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ProductResponse>> Handle()
        {
            var products = await _repository.GetAllAsync();

            return products.Select(product => new ProductResponse
            {
                Id = product.Id,
                ProductCode = product.ProductCode,
                FormattedProductCode = ProductCodeFormatter.Format(product.ProductCode)
            }).ToList();
        }
    }
}
