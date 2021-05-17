using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryShopApi.Models.Validators
{
    public class CreateOrderItemDtoValidator : AbstractValidator<CreateOrderItemDto>
    {
        public CreateOrderItemDtoValidator()
        {
            RuleFor(x => x.Quantity)
                .NotEmpty();

            RuleFor(x => x.IdOrder)
               .NotEmpty();

            RuleFor(x => x.IdProduct)
                .NotEmpty();

        }
    }
}
