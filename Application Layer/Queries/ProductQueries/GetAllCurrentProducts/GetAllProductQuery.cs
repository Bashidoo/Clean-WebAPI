using MediatR;
using Application_Layer.Common.Results;
using Application_Layer.Dtos;
using Domain_Layer.Models;
using MediatR;
using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Layer.Queries.ProductQueries.GetAllCurrentProducts
{
    public class GetAllProductQuery : IRequest<OperationResult>
    {

    }
}
