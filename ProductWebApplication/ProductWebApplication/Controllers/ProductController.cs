using Day1Part1.Data;
using Day1Part1.Models;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Day1Part1.DAO;
using Final.DAO;

namespace Day1Part1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IProductDAO productDao;
        private IProductDAO _productDao;

        public ProductController(IProductDAO productDao)
        {
            _productDao = productDao;
        }
    }

    //private readonly IProductRepository _productRepository;
    //    public ProductController(IProductRepository productRepository)
    //    {
    //        _productRepository = productRepository;
    //    }

    //    [Route("/")]
    //    [Route("")]
    //    [Route("index")]
    [HttpGet]
    public async Task<ActionResult<List<Product>>> GetProducts()
    {
        var products = await _productRepository.GetProducts();
        if (products == null)
        {
            return NotFound();
        }
        return Ok(products);
    }

    [HttpGet("{id}", Name = "GetProduct")]
    public async Task<ActionResult<Product>> GetProduct(int id)
    {
        Product? pdtFound = await _productRepository.GetProductById(id);
        if (pdtFound == null)
        {
            return NotFound();
        }
        else
        {
            return Ok(pdtFound);
        }
    }



    [Httpput("{id}")]
    public async Task<ActionResult<Product>> updateproductprice(int id, double price)
    {
        Product? product = null;
        product = await _productrepository.updateproductprice(id, price);
        if (product != null)
        {
            return nocontent();
        }
        else
        {
            return notfound("id not found");
        }

    }


    [HttpGet("by-price-range")]
    public async Task<ActionResult<List<Product>>> GetProductsByPriceRange([FromQuery] double minPrice, [FromQuery] double maxPrice)
    {
        if (minPrice < 0 || maxPrice < 0 || minPrice > maxPrice)
        {
            return BadRequest("Invalid price range.");
        }

        var products = await _productDAO.GetProductsByPriceRange(minPrice, maxPrice);

        if (products == null || products.Count == 0)
        {
            return NotFound("No products found in the specified price range.");
        }

        return Ok(products);
    }




    //    [HttpPost]
    //    public async Task<ActionResult<Product>> CreateProduct(Product product)
    //    {
    //        if (product != null)
    //        {
    //            bool res = await _productRepository.CreateProduct(product);
    //            if (res)
    //            {
    //                return CreatedAtRoute(nameof(GetProduct), new { id = product.ProductId }, product);
    //            }
    //            return BadRequest("Failed to Add the Product.");
    //        }
    //        else
    //        {
    //            return BadRequest();
    //        }
    //    }

    //[HttpSort]
    //public async Task<ActionResult<Product>> AddProduct(Product product)
    //{
    //    if (product != null)
    //    {
    //        if (ModelState.IsValid)
    //        {

    //            bool res = await _productRepository.AddProduct(product);
    //            if (res)
    //            {
    //                return CreatedAtRoute(nameof(GetProduct), new { id = product.ProductId }, product);
    //            }
    //            return BadRequest("Failed to Add the Product.");
    //        }
    //        else
    //        {
    //            return BadRequest();
    //        }
    //    }
    //}


    [HttpDelete("{id}")]
    public async Task<ActionResult> RemoveProduct(int id)
    {
        bool isDeleted = false;
        isDeleted = await _productRepository.RemoveProduct(id);
        if (isDeleted)
        {
            return NoContent();
        }
        else
        {
            return NotFound("Product Not Deleted.");
        }
    }

    [HttpGet("count")]
    public async Task<ActionResult<int>> Count()
    {
        int count = await _productDao.GetTotalProductCount();

        return Ok(count);

    }


    //    //[HttpGet("{name:alpha}")]
    //    [HttpGet(@"{name:regex(^[[a-zA-Z ]]+$)}")]
    //    public async Task<ActionResult<List<Product>>> GetProductByName(string name)
    //    {
    //        List<Product> list = null;
    //        list = await _productRepository.GetProductByName(name);
    //        if (list != null)
    //        {
    //            return Ok(list);
    //        }
    //        else
    //        {
    //            return NotFound("No Product Found");

    //        }
    //    }

    //    [HttpGet("{rating:double}")]
    //    public async Task<ActionResult<List<Product>>> GetProductByRating(double rating)
    //    {
    //        List<Product> list = null;
    //        list = await _productRepository.GetProductByRating(rating);
    //        if (list != null)
    //        {
    //            return Ok(list);
    //        }
    //        else
    //        {
    //            return NotFound("No Product Found");
    //        }
    //    }

    //    //[HttpGet(@"productcode/{productcode:regex()")]

    //    [HttpGet("productCode/{productCode}")]
    //    public async Task<ActionResult<Product>> GetProductByProductCode(string productCode)
    //    {
    //        Product? pdtFound = null;
    //        pdtFound = await _productRepository.GetProductByProductCode(productCode);
    //        if (pdtFound != null)
    //        {
    //            return Ok(pdtFound);
    //        }
    //        else
    //        {
    //            return NotFound("No Product Found.");
    //        }
    //    }
    //}
}