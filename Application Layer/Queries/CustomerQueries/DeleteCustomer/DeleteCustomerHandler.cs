using Application_Layer.Interfaces.CustomerInterface;
using Domain_Layer.Models;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Layer.Queries.CustomerQueries.DeleteCustomer
{
    public class DeleteCustomerHandler : IRequestHandler<DeleteCustomerQuery, string>
    {
        private readonly ICustomerRepository _customerrepository;


        private readonly ILogger<DeleteCustomerHandler> _logger;
        public DeleteCustomerHandler(ICustomerRepository customerrepository, ILogger<DeleteCustomerHandler> logger)
        {
            _customerrepository = customerrepository;
            _logger = logger;

        }

        public async Task<string> Handle(DeleteCustomerQuery request, CancellationToken cancellationToken)
        {
            bool isDeleted = await _customerrepository.RemoveCustomerAsync(request.customerName);
            return isDeleted ? "Success" : "Error";
        }
    }
}
