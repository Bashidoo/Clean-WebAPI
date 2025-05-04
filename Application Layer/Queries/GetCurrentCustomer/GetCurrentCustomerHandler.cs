using Application_Layer.Interfaces.CustomerInterface;
using Domain_Layer.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Layer.Queries.GetCurrentCustomer
{
    public class GetCurrentCustomerHandler : IRequestHandler<GetCurrentCustomerQuery, Customer>
    {
        private readonly ICustomerRepository _customerRepository;

        public GetCurrentCustomerHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public Task<Customer> Handle(GetCurrentCustomerQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_customerRepository.GetCurrentCustomerFromDB());
        }
    }
}
