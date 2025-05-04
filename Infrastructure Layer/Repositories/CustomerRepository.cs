using Application_Layer.Interfaces.CustomerInterface;
using Domain_Layer.Models;
using Infrastructure_Layer.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure_Layer.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {

        // Connection between DB and CRUD

        private readonly AppDbContext _theDatabase;

        public CustomerRepository(AppDbContext appDbcontext)
        {
            _theDatabase = appDbcontext;
        }
        public Customer GetCurrentCustomerFromDB()
        {
            string defaultCustomerName = "Busherino";
            string defaultCustomerEmail = "busherino.Demolino.com";
            Customer customer1 = new Customer()
            {
                Name = defaultCustomerName,
                Email = defaultCustomerEmail
            };

            return _theDatabase.Customers.FirstOrDefault() ?? customer1; 
        }
    }
}
