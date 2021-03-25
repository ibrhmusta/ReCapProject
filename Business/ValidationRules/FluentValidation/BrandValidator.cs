using Core.Constants;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class BrandValidator :AbstractValidator<Brand>
    {
        public BrandValidator()
        {
            RuleFor(b => b.BrandName).NotEmpty().WithMessage(AspectMessages.CanNotBeBlank);
            RuleFor(b => b.BrandName).MinimumLength(2);
            
            RuleFor(b => b.BrandModel).NotEmpty().WithMessage(AspectMessages.CanNotBeBlank);
            RuleFor(b => b.BrandModel).MinimumLength(2);
        }
    }
}