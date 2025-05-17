using Application_Layer.Common.Results;
using Application_Layer.Dtos.ReponseDtos;
using Application_Layer.Interfaces.CustomerInterface;
using Application_Layer.Interfaces.ProductInterface;
using Application_Layer.Queries.CustomerQueries.CreateACustomer;
using AutoMapper;
using Domain_Layer.Models;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Layer.Queries.ProductQueries.CreateAProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandQuery, OperationResult>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateProductCommandHandler> _logger;
        public CreateProductCommandHandler(IProductRepository customerRepository,
            IMapper mapper,
            ILogger<CreateProductCommandHandler> logger) 
        {
            _productRepository = customerRepository;
            _mapper = mapper;
            _logger = logger;

        }

        public async Task<OperationResult> Handle(CreateProductCommandQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var product = _mapper.Map<Product>(request.ProductDto);

                var savedProduct = await _productRepository.AddProductAsync(product);


                _logger.LogInformation("Created product {ProductName} with ID {Product.Id}", savedProduct.Name, savedProduct.Id);

                return OperationResult.SuccessOBJ($" Successfully created product: {savedProduct.Name}", new { savedProduct.Id, savedProduct.Name, savedProduct.Price, savedProduct.Description });


            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating product");
                return OperationResult.Failure($"Error: {ex.Message}");

            }

        }
    }
}
