using AmassTest.Application.Interfaces;
using AmassTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmassTest.Application.Features.Products.CreateProduct
{
    public class CreateProductHandler
    {
        private readonly IProductRepository _repository;
        public CreateProductHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateProductCommand command)
        {
            var product = new Product
            {
                ProductCode = command.productCode.Replace("-", "")
            };
            await _repository.AddAsync(product);
        }
    }
}
