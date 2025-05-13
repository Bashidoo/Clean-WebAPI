using Application_Layer.Common.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Layer.Queries.ProductQueries.DeleteProduct
{
    public class DeleteProductQuery : IRequest<OperationResult>
    {
        public double ProductId { get; set; }
        public DeleteProductQuery(double productId)
        {
            ProductId = productId;
        }
    }
}
