using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class AuthValidator : AbstractValidator<UserForRegisterDto>
    {
        public AuthValidator()
        {
            RuleFor(u => u.FirstName).NotEmpty();
            RuleFor(u => u.FirstName).MinimumLength(2);
            RuleFor(u => u.LastName).NotEmpty();
            RuleFor(u => u.LastName).MinimumLength(2);
            RuleFor(u => u.Email).NotEmpty();
            RuleFor(u => u.Email).EmailAddress();
            RuleFor(u => u.Password).NotEmpty();
            RuleFor(u => u.Password).MinimumLength(8).WithMessage("Password must be at least 8 character long"); ;
            RuleFor(u => u.Password).Must(ContainCharachters).WithMessage("Password must contain digit, symbol, upper and lower case letter");

        }

        private bool ContainCharachters(string arg)
        {
            if (arg.Any(char.IsUpper) && arg.Any(char.IsLower) && arg.Any(char.IsDigit) && arg.Any(char.IsPunctuation))
            {
                return true;
            }
            return false;
        }
    }
}
