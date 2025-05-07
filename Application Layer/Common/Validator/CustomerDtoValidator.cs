using Application_Layer.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Layer.Common.Validator
{
    public class CustomerDtoValidator : AbstractValidator<CustomerDto>
    {
        private static readonly string[] AllowedDomains = { ".com", ".net", ".se", ".org" };

        public CustomerDtoValidator()
        {
            RuleFor(customer => customer.Name)
                .NotEmpty().WithMessage("Name is required!")
                .MaximumLength(100);

            RuleFor(customer => customer.Email)
                .NotEmpty().WithMessage("Email is required")
                 .Must(email =>
                AllowedDomains.Any(d => email.EndsWith(d, StringComparison.OrdinalIgnoreCase)))
            .WithMessage("Email must end with “.com”, “.net”, “.se” or “.org”.");
        }
    }
}
