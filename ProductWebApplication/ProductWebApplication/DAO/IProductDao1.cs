using Day1Part1.Models;

namespace Final.DAO
{
    public interface IProductDao
    {
        Task<int> InsertProduct(Product p);
        Task<List<Product>> GetProducts();



        Task<int> UpdateProduct(Product p);

    }
}