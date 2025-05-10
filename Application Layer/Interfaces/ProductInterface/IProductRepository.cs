using Domain_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Layer.Interfaces.ProductInterface
{
    public interface IProductRepository
    {


        Task<Product> AddProductAsync(Product product);

        Product GetCurrentProductFromDB();
        Task<List<Product>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(string productID);

        Task<bool> UpdateProductAsync(Product product);

        Task<bool> RemoveProductAsync(string productID);
        
    }
}
