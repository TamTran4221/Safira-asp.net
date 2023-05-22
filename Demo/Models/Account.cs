using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.Models
{
    
        [Table("Accounts")]
        public class Account
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
        }
    }
