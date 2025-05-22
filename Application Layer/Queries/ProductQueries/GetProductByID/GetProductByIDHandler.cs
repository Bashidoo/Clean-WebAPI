using Application_Layer.Common.Results;
using Application_Layer.Dtos;
using Application_Layer.Interfaces.CustomerInterface;
using Application_Layer.Interfaces.ProductInterface;
using Application_Layer.Queries.CustomerQueries.UpdateACustomer;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Layer.Queries.ProductQueries.GetProductByID
{
    public class GetProductByIDHandler : IRequestHandler<GetProductByIDQuery, OperationResult>
    {
        private readonly IProductRepository _productRepository;
        private readonly ILogger<GetProductByIDHandler> _logger;
        private readonly IMapper _mapper;

        public GetProductByIDHandler(IProductRepository productrepository, ILogger<GetProductByIDHandler> logger, IMapper mapper)
        {
            _productRepository = productrepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<OperationResult> Handle(GetProductByIDQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var existingProduct = await _productRepository.GetProductByIdAsync(request.productID);

                if (existingProduct == null)
                {
                    _logger.LogWarning("Product with ID {ID} not found.", request.productID);
                    return OperationResult.Failure($"Product with ID {request.productID} not found.");
                }
                var productDTO = _mapper.Map<ProductDto>(existingProduct);

                return OperationResult.SuccessOBJ($"Successfully found product \n Name: {productDTO.Name}\n Description: {productDTO.Description}\n Price: {productDTO.Price}", productDTO);

               
            }
            catch (Exception ex)
            {
                _logger.LogWarning("");
                return OperationResult.Failure($"");
            }
        }
    }
}
