using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.Models
{
    [Table("Carts")]
    public class Cart
    {
       
        public int AccountId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
        public Product product { get; set; }

    }
}
