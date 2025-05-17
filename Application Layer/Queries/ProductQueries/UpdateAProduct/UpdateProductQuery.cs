using Application_Layer.Common.Results;
using Application_Layer.Dtos;
using Application_Layer.Dtos.ReponseDtos;
using Domain_Layer.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Layer.Queries.ProductQueries.UpdateAProduct
{
    public class UpdateProductQuery : IRequest<OperationResult>
    {

        public ProductResponseDto ProductToUpdate { get; }

        public UpdateProductQuery(ProductResponseDto producttoupdate)
        {
            ProductToUpdate = producttoupdate;
        }
    }
}
