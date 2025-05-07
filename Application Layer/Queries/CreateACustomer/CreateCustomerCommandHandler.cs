using Application_Layer.Interfaces.CustomerInterface;
using Application_Layer.Dtos;
using AutoMapper;
using Domain_Layer.Models;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Application_Layer.Queries.CreateACustomer
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommandQuery, string>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateCustomerCommandHandler> _logger;

        public CreateCustomerCommandHandler(
            ICustomerRepository customerRepository,
            IMapper mapper,
            ILogger<CreateCustomerCommandHandler> logger)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<string> Handle(CreateCustomerCommandQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var customer = _mapper.Map<Customer>(request.CustomerDto);

                // Save and retrieve the actual saved entity
                var savedCustomer = await _customerRepository.AddCustomerAsync(customer);

                if (savedCustomer.Id == 0)
                {
                    _logger.LogError("Database failed to generate ID for customer {CustomerName}", savedCustomer.Name);
                    return "Error: Failed to generate customer ID";
                }

                _logger.LogInformation("Created customer {CustomerName} with ID {CustomerId}",
                    savedCustomer.Name, savedCustomer.Id);

                return $"Successfully created customer: {savedCustomer.Name} (ID: {savedCustomer.Id})";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating customer");
                return $"Error: {ex.Message} | Inner: {ex.InnerException?.Message}";
            }
        }

    }
}