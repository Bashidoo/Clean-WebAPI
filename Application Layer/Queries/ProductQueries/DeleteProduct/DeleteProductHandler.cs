using Application_Layer.Common.Results;
using Application_Layer.Interfaces.CustomerInterface;
using Application_Layer.Interfaces.ProductInterface;
using Application_Layer.Queries.CustomerQueries.DeleteCustomer;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Layer.Queries.ProductQueries.DeleteProduct
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductQuery, OperationResult>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productrepository;

        private readonly ILogger<DeleteProductHandler> _logger;
        public DeleteProductHandler(IProductRepository productrepository, ILogger<DeleteProductHandler> logger, IMapper mapper)
        {
            _mapper = mapper;
            _productrepository = productrepository;
            _logger = logger;

        }

        public async Task<OperationResult> Handle(DeleteProductQuery request, CancellationToken cancellationToken)
        {

            try
            {
              
             
                var productToDelete = await _productrepository.RemoveProductAsync(request.ProductId);

                _logger.LogInformation($"Deleted product with ID:{request.ProductId} : Name {productToDelete.Name}");
                return OperationResult.Success($" Successfuly deleted product:{productToDelete.Name} ");


            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                return OperationResult.Failure($"Failed to delete product. Reason: {ex.Message}");
            }
        }
    }
}
