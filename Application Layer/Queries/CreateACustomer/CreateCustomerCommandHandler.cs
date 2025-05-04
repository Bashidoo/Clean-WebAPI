using Application_Layer.Interfaces.CustomerInterface;
using Application_Layer.Dtos;
using AutoMapper;
using Domain_Layer.Models;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Layer.Queries.CreateACustomer
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommandQuery, string>
    {
        private readonly ICustomerRepository _customerrepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateCustomerCommandHandler> _logger;

        public CreateCustomerCommandHandler(ICustomerRepository customerRepository, IMapper mapper,
        ILogger<CreateCustomerCommandHandler> logger)
        {
            _customerrepository = customerRepository;
            _mapper = mapper;
            _logger = logger;

        }

        public async Task<string> Handle(CreateCustomerCommandQuery request, CancellationToken cancellationToken)
        {

            // Map DTO to Domain Entity using AutoMapper
            var customer = _mapper.Map<Customer>(request.CustomerDto);

            await _customerrepository.AddCustomerAsync(customer);
            

            return $"Created customer: {customer.Name}";


        }
    }
}
