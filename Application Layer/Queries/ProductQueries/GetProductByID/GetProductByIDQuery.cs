using Application_Layer.Common.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Layer.Queries.ProductQueries.GetProductByID
{
    public class GetProductByIDQuery : IRequest<OperationResult>
    {
        public double productID;

        public GetProductByIDQuery(double productid)
        {
            productID = productid;
        }
    }
}
