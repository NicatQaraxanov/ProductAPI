using DomainModels.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidatorService.Validators
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.ProductName).NotNull().Length(3, 15);
            RuleFor(x => x.Price).NotNull().InclusiveBetween(1, 100);
            RuleFor(x => x.IsDeleted).NotNull();
        }
    }
}
