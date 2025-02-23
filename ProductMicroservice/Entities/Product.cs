using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductMicroservice.Entities
{
    public class Product
    {
       
       
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Catagory { get; set; }
        public string Brand { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
