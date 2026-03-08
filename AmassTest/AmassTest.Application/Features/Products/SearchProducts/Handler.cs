using AmassTest.Application.Common.Helpers;
using AmassTest.Application.Features.Products.GetProducts;
using AmassTest.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmassTest.Application.Features.Products.SearchProducts
{
    public class SearchProductsHandler
    {
        private readonly IProductRepository _repository;
        public SearchProductsHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ProductResponse>> Handle(SearchProductQuery query)
        {
            var products = await _repository.SearchByKeywordAsync(query.keyword);
            return products.Select(product => new ProductResponse
            {
                Id = product.Id,
                ProductCode = product.ProductCode,
                FormattedProductCode = ProductCodeFormatter.Format(product.ProductCode)
            }).ToList();
        }
    }
}
