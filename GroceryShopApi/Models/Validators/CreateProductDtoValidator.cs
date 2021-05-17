using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryShopApi.Models.Validators
{
    public class CreateProductDtoValidator : AbstractValidator<CreateProductDto>
    {
        public CreateProductDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().
                MaximumLength(25);

            RuleFor(x => x.Price)
               .NotEmpty();

            RuleFor(x => x.Quantity)
               .NotEmpty();

        }
    }
}
