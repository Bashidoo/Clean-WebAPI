using Application_Layer.Common.Results;
using Application_Layer.Dtos;
using Application_Layer.Interfaces.ProductInterface;
using AutoMapper;
using Domain_Layer.Models;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Layer.Queries.ProductQueries.GetAllCurrentProducts
{
    public class GetAllProductsHandler : IRequestHandler<GetAllProductQuery, OperationResult>
    {
        private readonly ILogger _logger;
        private readonly IProductRepository _productrepository;
        private readonly IMapper _mapper;
        public GetAllProductsHandler(IProductRepository productrepository, ILogger logger, IMapper mapper)
        {
            _productrepository = productrepository;
            _logger = logger;
            _mapper = mapper;
            
        }

        public async Task<OperationResult> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {

            try
            {
                _logger.LogInformation("Fetching all products.....");

                List<Product> products = await _productrepository.GetAllProductsAsync();

                if (products == null)
                {
                    _logger.LogWarning("Fetching all products attempted. No Products found!");
                    return OperationResult.Failure("No products found!");
                }
                List<ProductDto> productsDto = _mapper.Map<List<ProductDto>>(products);
                _logger.LogInformation($"Successfuly fetched: {productsDto.Count}");
                return OperationResult.SuccessOBJ($"List of Products: ", productsDto);
            }
            catch (Exception ex)
            {
                _logger.LogWarning($"{ex.Message}", ex);
               return  OperationResult.Failure($"Error: {ex.Message}");
            }
        }
    }
}
