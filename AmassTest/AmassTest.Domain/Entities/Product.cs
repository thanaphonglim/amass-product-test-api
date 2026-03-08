using AmassTest.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmassTest.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductCode { get; private set; }
        private Product(string productCode)
        {
            ProductCode = productCode;
        }

        public static Product Create()
        {
            var code = ProductCodeGenerator.GenerateProductCode();
            return new Product(code);
        }
    }
}
