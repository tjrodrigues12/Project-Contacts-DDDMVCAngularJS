using System;
using System.Collections.Generic;
using System.Text;

using FluentValidation;
using Project.Domain.Entities;

namespace Project.Service.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u)
                .NotNull()
                .OnAnyFailure(x =>
                {
                    throw new ArgumentNullException("Can't found the object.");
                });


            RuleFor(c => c.DocumentNumber)
                .NotEmpty().WithMessage("Is necessary to inform the Document Number")
                .NotNull().WithMessage("Is necessary to inform the Document Number");
            
            RuleFor(c => c.BirthDate)
                .NotEmpty().WithMessage("Is necessary to inform the CPF")
                .NotNull().WithMessage("Is necessary to inform the CPF");

            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Is necessary to inform the CPF")
                .NotNull().WithMessage("Is necessary to inform the CPF");

        }
    }
}
