using Application_Layer.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Layer.Queries.GetAllCurrentCustomer
{
    public class GetAllCurrentCustomerQuery : IRequest<List<CustomerDto>>
    {
    }
}
