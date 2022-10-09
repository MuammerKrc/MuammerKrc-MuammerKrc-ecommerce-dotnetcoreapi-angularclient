using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Application.Dtos.ProductDtos;
using FluentValidation;

namespace ECommerce.Application.Validators.Products
{
    public class ProductCreateValidator : AbstractValidator<ProductCreateDto>
    {
        public ProductCreateValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().WithMessage(FluentErrorDesc.NotNull).MaximumLength(100).WithMessage(FluentErrorDesc.MaxLength(100));

            RuleFor(p => p.Stock).NotEmpty().NotNull().WithMessage(FluentErrorDesc.NotNull).Must(s => s >= 0)
                .WithMessage(FluentErrorDesc.minNumberDesc(0));

            RuleFor(p => p.Price).NotEmpty().NotNull().WithMessage(FluentErrorDesc.NotNull).Must(s => s >= 0)
                .WithMessage(FluentErrorDesc.minNumberDesc(0));
        }
    }
}
