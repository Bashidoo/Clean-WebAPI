using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Layer.Queries.CustomerQueries.DeleteCustomer
{
    public class DeleteCustomerQuery : IRequest<string>
    {
        public string customerName { get; set; }

        public DeleteCustomerQuery(string customername)
        {
            customerName = customername;
        }
    }
}
