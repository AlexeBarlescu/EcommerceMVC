using System.ComponentModel.DataAnnotations.Schema;

namespace Web.Models
{
    public class Product
    {
        public Product() { }

        public Product(string productName, string category, decimal price, 
            decimal? salePrice, int stock, string imageUrl)
        {
            ProductName = productName;
            Category = category;
            Price = price;
            SalePrice = salePrice;
            Stock = stock;
            ImageUrl = imageUrl;
        }
        
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }
        [Column(TypeName = "decimal(8,2)")]
        public decimal Price { get; set; }
        [Column(TypeName = "decimal(8,2)")]
        public decimal? SalePrice { get; set; }
        public int Stock { get; set; }
        public string ImageUrl { get; set; }
    }
}
