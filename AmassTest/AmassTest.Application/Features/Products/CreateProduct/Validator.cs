using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace AmassTest.Application.Features.Products.CreateProduct
{
    public class CreateProductValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductValidator()
        {
            RuleFor(x => x.productCode)
                .NotEmpty()
                .Matches(@"^[A-Z0-9]{4}-[A-Z0-9]{4}-[A-Z0-9]{4}-[A-Z0-9]{4}$")
                .WithMessage("รหัสสินค้าจะเป็นได้ทั้งตัวเลข และตัวอักษรภาษาอังกฤษพิมพ์ใหญ่เท่านั้น มีขนาดความยาว 16 หลัก (Format XXXX-XXXX-XXXX-XXXX)");
        }
    }
}
