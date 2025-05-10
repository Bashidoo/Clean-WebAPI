using Application_Layer.Common.Validator;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Layer.Queries.CustomerQueries.CreateACustomer
{
    public class CreateCustoemrCommandValidator : AbstractValidator<CreateCustomerCommandQuery>
    {
        public CreateCustoemrCommandValidator()
        {
            RuleFor(x => x.CustomerDto)
            .SetValidator(new CustomerDtoValidator());
        }
    }
}
