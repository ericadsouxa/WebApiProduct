using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices.JavaScript;

namespace Day1Part1.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        [Required (ErrorMessage ="Provide a Product Name")]
        [MaxLength(20)]
        public string ProductName { get; set; }
        [Required]
        
        public double Price { get; set; }
        public string Category { get; set; }
        [Range (1,5,ErrorMessage ="StarRating can be with the range 1-5")]
        public double StarRating { get; set; }
        [AllowNull]
        public string Description { get; set; }
        public string ProductCode { get; set; }
        public string ImageUrl { get; set; }
        public int id { get; internal set; }
        public string Name { get; internal set; }
    }
}