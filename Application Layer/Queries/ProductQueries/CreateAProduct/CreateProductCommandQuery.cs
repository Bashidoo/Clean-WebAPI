using Application_Layer.Common.Results;
using Application_Layer.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Layer.Queries.ProductQueries.CreateAProduct
{
    public class CreateProductCommandQuery : IRequest<OperationResult>
    {
        public ProductDto ProductDto { get; set; }
        public CreateProductCommandQuery(ProductDto productdto)
        {
            ProductDto = productdto;
        }
    }
}
