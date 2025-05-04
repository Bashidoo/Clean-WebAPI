using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Layer.Models
{
    public class Customer
    {
        public double Id { get; set; } 
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime DateJoined { get; set; } = DateTime.UtcNow;

        public ICollection<Order> Orders { get; set; } = new List<Order>();


    }
}
