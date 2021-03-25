﻿using Core.Constants;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(c => c.CompanyName).NotEmpty().WithMessage(AspectMessages.CanNotBeBlank);
            RuleFor(c => c.CompanyName).MinimumLength(2);
            
        }
    }
}