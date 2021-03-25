using Core.Constants;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class ColorValidator : AbstractValidator<Color>
    {
        public ColorValidator()
        {
            RuleFor(c => c.ColorName).NotEmpty().WithMessage(AspectMessages.CanNotBeBlank);
            RuleFor(c => c.ColorName).MinimumLength(2);
        }
    }
}