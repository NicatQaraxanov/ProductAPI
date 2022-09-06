using DomainModels.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidatorService.Validators
{
    public class ProductCategoryValidator : AbstractValidator<ProductCategory>
    {
        public ProductCategoryValidator()
        {
            RuleFor(x => x.ProductCategoryName).NotNull().WithMessage("Product Category name required").Length(3, 15).WithMessage("Product Category name length not valid");
        }
    }
}
