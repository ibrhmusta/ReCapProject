using System.Text.RegularExpressions;
using Core.Constants;
using Core.Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator :AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.FirstName).NotEmpty().WithMessage(AspectMessages.CanNotBeBlank);
            RuleFor(u => u.FirstName).MinimumLength(2);
            
            
            RuleFor(u => u.LastName).NotEmpty().WithMessage(AspectMessages.CanNotBeBlank);
            RuleFor(u => u.LastName).MinimumLength(2);

            RuleFor(u => u.Email).NotEmpty().WithMessage(AspectMessages.CanNotBeBlank);
            RuleFor(u => u.Email).EmailAddress().WithMessage(AspectMessages.InvalidEmailAddress);

            // RuleFor(u => u.Password).NotEmpty().WithMessage("Password cannot be blank.");
            // RuleFor(u => u.Password).Must(IsPasswordValid).WithMessage("Your password must contain at least eight characters, at least one letter and one number!");
        }
        
        //private bool IsPasswordValid(string arg)
        //{
        //    Regex regex = new Regex(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$");
        //    return regex.IsMatch(arg);
        //}
        
    }
}