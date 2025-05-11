using Application_Layer.Interfaces.ProductInterface;
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
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _theDatabase;
        public ProductRepository(AppDbContext theDatabase)
        {
            _theDatabase = theDatabase;
        }

        public async Task<Product> AddProductAsync(Product product)
        {
            _theDatabase.Products.Add(product);
            await _theDatabase.SaveChangesAsync();
            return product;
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await _theDatabase.Products.ToListAsync();
        }

        public Product? GetCurrentProductFromDB()
        {
            return _theDatabase.Products.FirstOrDefault();
        }

        public async Task<Product?> GetProductByIdAsync(double productId)
        {
            return await _theDatabase.Products.FindAsync(productId);
        }

        public async Task<Product?> GetProductByNameAsync(string productName)
        {
            return await _theDatabase.Products.FindAsync(productName);
        }

        public async Task<bool> RemoveProductAsync(double productID)
        {
            var productToFind = await _theDatabase.Products.FirstOrDefaultAsync(x => x.Id == productID);

            if (productToFind == null)
                return false;

            _theDatabase.Products.Remove(productToFind);
            await _theDatabase.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateProductAsync(Product product)
        {
           _theDatabase.Products.Update(product);


            await _theDatabase.SaveChangesAsync();
            return true;
        }
    }
}
