using Application_Layer.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Layer.Common.Validator
{
    public class ProductDtoValidator : AbstractValidator<ProductDto>
    {
        public ProductDtoValidator()
        {

            RuleFor(product => product.Name)
                .NotEmpty().WithMessage("Name is required!")
                .MaximumLength(100);

            RuleFor(product => product.Description)
                .NotEmpty().WithMessage("Description is required!");

            RuleFor(product => product.Price)
                .NotEmpty().WithMessage("Price is Required!");
        }
    }
}
