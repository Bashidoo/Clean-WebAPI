using Application_Layer.Common.Results;
using Application_Layer.Interfaces.ProductInterface;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Layer.Queries.ProductQueries.UpdateAProduct
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductQuery, OperationResult>
    {
        private readonly IProductRepository _productrepository;
        private readonly ILogger<UpdateProductHandler> _logger;
        private readonly IMapper _mapper;

        public UpdateProductHandler(IProductRepository productrepository,ILogger<UpdateProductHandler> logger,IMapper mapper)
        {
            _productrepository = productrepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<OperationResult> Handle(UpdateProductQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var existingProduct = await _productrepository.GetProductByIdAsync(request.ProductToUpdate.Id);

                if (existingProduct == null)
                {
                    _logger.LogWarning("Product with ID {ID} not found.", request.ProductToUpdate.Id);
                    return OperationResult.Failure($"Product with ID {request.ProductToUpdate.Id} not found.");
                }
                _mapper.Map(request.ProductToUpdate, existingProduct);

                await _productrepository.UpdateProductAsync(existingProduct);

                _logger.LogInformation($"Updated product with ID: {existingProduct.Id}");
                return OperationResult.SuccessOBJ($"Successfully updated product details ID:{existingProduct.Id}\n Name: {existingProduct.Name} \n Description: {existingProduct.Description}\n Price: {existingProduct.Price}", existingProduct);

            }
            catch (Exception ex)
            {
                _logger.LogWarning($"Could not find product ID: {request.ProductToUpdate?.Id}\n Reason: {ex.Message}");
                return OperationResult.Failure($"Failed to find product with ID: {request.ProductToUpdate?.Id}, Reason: {ex.Message}");

            }

        }
    }
}
