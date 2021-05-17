using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryShopApi.Models.Validators
{
    public class CreateClientDtoValidator : AbstractValidator<CreateClientDto>
    {
        public CreateClientDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(25);
            RuleFor(x => x.LastName)
               .NotEmpty()
               .MaximumLength(25);
            RuleFor(x => x.City)
               .NotEmpty()
               .MaximumLength(25);

        }

    }
}
