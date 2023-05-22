using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.Models
{
    [Table("Categories")]
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Product> products { get; set; }

    }
}
