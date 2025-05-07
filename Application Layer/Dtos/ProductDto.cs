 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Layer.Dtos
{
    public class ProductDto
    {
        public string Name { get; set; } = string.Empty;
        public double Price { get; set; } = 0;
        public string Description { get; set; } = string.Empty;
    }
}
