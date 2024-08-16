using Day1Part1.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
namespace Day1Part1.Data
{
    public class ProductRepositoryImplementation : IProductRepository
    {
        List<Product> productList = new List<Product> {
        new Product{ ProductId=1,ProductName="Soccer Ball" , ProductCode ="SOB-BAL",Price=2000, Category="Soccer" ,ImageUrl=@"assets/images/socccerball.jpeg", Description="There are many variations of passages of Lorem Ipsum available",StarRating=4.5},
        new Product{ ProductId=2,ProductName="Kayak" , Price=10000,ProductCode ="WAT-KAK" ,Category="WaterSports" ,ImageUrl=@"assets/images/kayak.jpeg", Description="There are many variations of passages of Lorem Ipsum available",StarRating=3.7},
        new Product{ ProductId=3,ProductName="Life Jacket" , Price=800,ProductCode ="WAS-LJA" ,Category="Water Sports", ImageUrl=@"assets/images/lifeJacket.jpeg", Description="There are many variations of passages of Lorem Ipsum available",StarRating=2.5},
        new Product{ ProductId=4,ProductName="Chess Board" , Price=200,ProductCode ="IDG-CHB", Category="Indoor Games",ImageUrl=@"assets/images/chessboard.jpeg", Description="There are many variations of passages of Lorem Ipsum available",StarRating=4.3},
        new Product{ ProductId=5,ProductName="Carrom Coins" ,ProductCode ="IDG-CAC" ,Price=700, Category="Indoor Games",ImageUrl=@"assets/images/carromcoins.jpeg", Description="There are many variations of passages of Lorem Ipsum available",StarRating=3.5},
        };

        public Task<List<Product>> GetProducts()
        {
            String query = @"select * from practice.product";
            List<Product> products = new List<Product>();
        }
   
            
        public Task<Product?> GetProductById(int id)
        {
            Task<Product?> pdtFound = Task.Run(() => productList.SingleOrDefault(x => x.ProductId == id));
            if (pdtFound != null)
            {
                return pdtFound;
            }
            else
            {
                return null;
            }
        }

        public async Task<Product?> UpdateProductPrice(int id, double newPrice)
        {
            Product? product = null;
            product = await GetProductById(id);
            if (product != null)
            {
                product.Price = newPrice;
            }
            return product;
        }

        public Task<bool> CreateProduct(Product product)
        {
            bool isAdded = false;
            if (product != null)
            {
                // Write logic to check if the product has been added
                // and if true, return true.
                int length = productList.Count;
                productList.Add(product);
                if (productList.Count == length + 1)
                {
                    isAdded = true;
                }
            }
            return Task.FromResult(isAdded);
        }
        public async Task<bool> RemoveProduct(int id)
        {
            bool isRemoved = false;
            Product? pdt = await GetProductById(id);
            if (pdt != null)
            {
                isRemoved = productList.Remove(pdt);
            }
            return isRemoved;
        }


        public Task<bool> UpdateProductPriceById(int id , double newPrice)
        {
            bool isUpdated = false ;
            string query = $"update practice.product set price = @price where product_id = @pid";

            using(_connection )
            {

            }
        }

        public Task<List<Product>> GetProductByName(string name)
        {
            List<Product> productsFound = productList.Where(x => x.ProductName.ToLower().Contains(name.ToLower())).ToList();
            return Task.Run(() => productsFound);
        }

        public Task<List<Product>> GetProductByRating(double rating)
        {
            List<Product> productsFound = null;
            productsFound = productList.Where(x => x.StarRating == rating).ToList();
            return Task.FromResult(productsFound);
        }


        //---------------------------------------------------------------------------------------//
        public Task<List<Product>> GetProductsByPriceRange(double minPrice, double maxPrice)
        {
            List<Product> productsFound = null;
            productsFound = productList.Where(x => x.Price >= minPrice && x.Price <= maxPrice).ToList();
            return Task.FromResult(productsFound);
        }

        //---------------------------------------------------------------------------------------//

        public Task<Product> GetProductByProductCode(string productCode)
        {
            Product? productsFound = null;
            productsFound = productList.FirstOrDefault(x => x.ProductCode == productCode);
            return Task.FromResult(productsFound);
        }
        public Task<Product> AddProduct(Product product) {
           
            return product;
        }
    }
}
