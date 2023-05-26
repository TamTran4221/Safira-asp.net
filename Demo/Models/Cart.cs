using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.Models
{
    [Table("Carts")]
    public class Cart
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }

    }
}
