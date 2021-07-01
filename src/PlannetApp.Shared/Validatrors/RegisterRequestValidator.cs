using FluentValidation;
using PlannetApp.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlannetApp.Shared.Validatrors
{
    public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
    {
        public RegisterRequestValidator()
        {
            RuleFor(p => p.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Enter valid email address");
            
            RuleFor(p => p.FirstName)
                .NotEmpty().WithMessage("First name is required")
                .MaximumLength(25).WithMessage("First name should not contain more over 25 chars");
            
            RuleFor(p => p.LastName)
                .NotEmpty().WithMessage("Last name is required")
                .MaximumLength(25).WithMessage("First name should not contain more over 25 chars");
           
            RuleFor(p => p.Password)
                .NotEmpty().WithMessage("Password is required ")
                .MinimumLength(5).WithMessage("password should at least 5 chars");
            
            RuleFor(p => p.ConfirmPassword)
                .Equal(p => p.Password).WithMessage("Confirm Password does not match password");
        }
    }
}
