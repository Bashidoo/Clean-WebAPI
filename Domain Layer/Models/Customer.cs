using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Layer.Models
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public double? Id { get; set; } 
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime DateJoined { get; set; } = DateTime.UtcNow;

        public ICollection<Order> Orders { get; set; } = new List<Order>();

        public Customer()
        {
            // This is just an example – you may want a more robust ID generator
            Id = new Random().Next(1000, 99999);
        }

    }
}
