using System;

using FluentValidation;
using Project.Domain.Entities;

namespace Project.Service.Validators
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(c => c)
                .NotNull()
                .OnAnyFailure(x =>
                {
                    throw new ArgumentNullException("Can't found the object.");

                });

            RuleFor(c => c.Name)
                        .NotEmpty().WithMessage("Is necessary to inform the Name")
                        .NotNull().WithMessage("Is necessary to inform the Name");


            RuleFor(c => c.CellPhone)
                    .NotEmpty().WithMessage("Is necessary to inform the CellPhone")
                    .NotNull().WithMessage("Is necessary to inform the CellPhone");

        }

    }
}
