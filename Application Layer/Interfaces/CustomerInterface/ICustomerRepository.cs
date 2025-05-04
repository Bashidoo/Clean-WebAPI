using Domain_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Layer.Interfaces.CustomerInterface
{
    public interface ICustomerRepository
    {
         Customer GetCurrentCustomerFromDB();
    }
}
