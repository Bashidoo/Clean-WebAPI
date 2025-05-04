using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain_Layer.Models
{
    public class Order
    {
        public double Id { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;

        // Customer ForeignKey
        public double CustomerId { get; set; }
        public Customer Customer { get; set; }

        // Product details
        public double ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
