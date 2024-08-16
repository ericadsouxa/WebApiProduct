using Day1Part1.Models;
//using Day1Part1.Models;
using Microsoft.AspNetCore.Mvc;
namespace Day1Part1.Data
{
    public interface IProductRepository
    {
        public Task<List<Product>> GetProducts();
        public Task<Product?> GetProductById(int id);

        public Task<List<Product?>> GetProductByRating(double rating);

        public Task<bool> RemoveProduct(int id);

        public Task<List<Product>> GetProductByName(string name);

        //public Task<List<Product>> GetProductsByName(string name);
        public Task<Product?> UpdateProductPrice(int id, double newPrice);
        public Task<bool> CreateProduct(Product product);

       public Task<ActionResult<Product>>AddProduct(Product product);
        public Task<Product?> GetProductByProductCode(string productCode);
    }
}