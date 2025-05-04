using Application_Layer.Interfaces.CustomerInterface;
using Application_Layer.Services;
using Domain_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Layer.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerrepository;

        public CustomerService(ICustomerRepository customerrepository)
        {
           _customerrepository = customerrepository;
        }


        public Customer GetCurrentCustomers()
        {
            return _customerrepository.GetCurrentCustomerFromDB();
        }
    }
}
