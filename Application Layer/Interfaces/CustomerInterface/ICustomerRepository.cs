using Application_Layer.Dtos;
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
        Task<bool> RemoveCustomerAsync(string customerName);
        Task<List<Customer>> GetAllCustomersAsync();
        Task<Customer> AddCustomerAsync(Customer customer);
         Customer GetCurrentCustomerFromDB();
        Task<Customer?> FindCustomerByNameAsync(string name);
        Task<bool> UpdateCustomerAsync(Customer customer);

    }
}
