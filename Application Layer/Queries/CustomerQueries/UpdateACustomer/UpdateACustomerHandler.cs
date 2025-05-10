using Application_Layer.Interfaces.CustomerInterface;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;

namespace Application_Layer.Queries.CustomerQueries.UpdateACustomer
{
    public class UpdateACustomerHandler : IRequestHandler<UpdateACustomerQuery, string>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ILogger<UpdateACustomerHandler> _logger;
        private readonly IMapper _mapper;

        public UpdateACustomerHandler(ICustomerRepository customerRepository, ILogger<UpdateACustomerHandler> logger, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<string> Handle(UpdateACustomerQuery request, CancellationToken cancellationToken)
        {
            var existingCustomer = await _customerRepository.FindCustomerByNameAsync(request.CustomerToUpdate.Name);
            if (existingCustomer == null)
            {
                _logger.LogWarning("Customer not found: {Name}", request.CustomerToUpdate.Name);
                return "Customer not found";
            }
            _mapper.Map(request.CustomerToUpdate, existingCustomer);
            await _customerRepository.UpdateCustomerAsync(existingCustomer);

            _logger.LogInformation("Updated customer {Name} in database", existingCustomer.Name);
            return $"Customer {existingCustomer.Name} updated successfully";
        }
    }
}
