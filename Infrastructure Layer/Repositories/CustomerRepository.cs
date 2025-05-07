using Application_Layer.Dtos;
using Application_Layer.Interfaces.CustomerInterface;
using Domain_Layer.Models;
using Infrastructure_Layer.Database;
using Microsoft.EntityFrameworkCore;
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

        public async Task<Customer> AddCustomerAsync(Customer customer)
        {
            _theDatabase.Customers.Add(customer);
            await _theDatabase.SaveChangesAsync();
            return customer;
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

        public async Task<List<Customer>> GetAllCustomersAsync()
        {
            return await _theDatabase.Customers.ToListAsync();
        }

        public async Task<bool> RemoveCustomerAsync(string customerName)
        {
            var customer = await _theDatabase.Customers
                .FirstOrDefaultAsync(c => c.Name == customerName);

            if (customer == null)
                return false;

            _theDatabase.Customers.Remove(customer);
            await _theDatabase.SaveChangesAsync();
            return true;
        }

        public async Task<Customer?> FindCustomerByNameAsync(string customerName)
        {
            return await _theDatabase.Customers.FindAsync(customerName);
        }

        public async Task<bool> UpdateCustomerAsync(Customer customer)
        {
            _theDatabase.Customers.Update(customer);
            await _theDatabase.SaveChangesAsync();
            return true;
        }
    }
}
