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

        Product? GetCurrentProductFromDB();
        Task<List<Product>> GetAllProductsAsync();
        Task<Product?> GetProductByNameAsync(string productName);
        Task<Product?> GetProductByIdAsync(double productId);

        Task<bool> UpdateProductAsync(Product productToUpdate);

        Task<Product?> RemoveProductAsync(double productId);
        
    }
}
