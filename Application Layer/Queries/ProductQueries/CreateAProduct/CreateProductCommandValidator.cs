using Application_Layer.Common.Validator;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Layer.Queries.ProductQueries.CreateAProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommandQuery>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(productobj => productobj.ProductDto).SetValidator(new ProductDtoValidator());
        }
    }
}
