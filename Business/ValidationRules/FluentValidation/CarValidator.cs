using System.Data;
using Core.Constants;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator :AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.DailyPrice).NotEmpty().WithMessage(AspectMessages.CanNotBeBlank);
            RuleFor(c => c.DailyPrice).GreaterThan(140);
            
            
            RuleFor(c => c.Description).NotEmpty().WithMessage(AspectMessages.CanNotBeBlank);
            RuleFor(c => c.Description).MinimumLength(10);
            
            RuleFor(c => c.ModelYear).NotEmpty().WithMessage(AspectMessages.CanNotBeBlank);
            
        }
    }
}