using AmassTest.Application.Common.Exceptions;
using AmassTest.Application.Interfaces;
using AmassTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;

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
            int retry = 5;
            while (retry-- > 0)
            {
                var product = Product.Create();

                try
                {
                    await _repository.AddAsync(product);
                    return;
                }
                catch (DuplicateProductCodeException){}
            }
        }
    }
}
