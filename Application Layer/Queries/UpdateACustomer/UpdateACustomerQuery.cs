using Application_Layer.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Layer.Queries.UpdateACustomer
{
    public class UpdateACustomerQuery : IRequest<string>
    {
        public CustomerDto CustomerToUpdate { get; set; }
        public UpdateACustomerQuery(CustomerDto customertoupdate) 
        {
            CustomerToUpdate = customertoupdate;
        }
    }
}
