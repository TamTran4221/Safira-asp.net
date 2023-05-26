using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.Models
{
    [Table("Products")]
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public double SalePrice { get; set; }
        public string Image { get; set; }
        public string Content { get; set; }
        public int CategoryId { get; set; }
        public Category category { get; set; }
        List<Cart> cart { get; set; }
        
    }
}
