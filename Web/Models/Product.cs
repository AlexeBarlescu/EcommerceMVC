using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Models
{
    public class Product
    {
        public Product() { }

        public Product(string productName, string category, double price, 
            double? salePrice, int stock, string imageUrl)
        {
            ProductName = productName;
            Category = category;
            Price = price;
            SalePrice = salePrice;
            Stock = stock;
            ImageUrl = imageUrl;
        }
        
        public int ProductId { get; set; }
        [Required(ErrorMessage = "Product name is required")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Product category is required")]
        public string Category { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "A valid price is required")]
        public double Price { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "A valid sale price is required")]
        public double? SalePrice { get; set; }
        public int Stock { get; set; }
        public string ImageUrl { get; set; }
    }
}
