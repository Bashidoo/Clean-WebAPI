using Application_Layer.Dtos;
using Domain_Layer.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Layer.Queries.CreateACustomer
{
    public class CreateCustomerCommandQuery : IRequest<string>
    {
        public CustomerDto CustomerDto { get; }
        public CreateCustomerCommandQuery(CustomerDto customerdto)
        {
            CustomerDto = customerdto;
        }
       

       
    }
}
