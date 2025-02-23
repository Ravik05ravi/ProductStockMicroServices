using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductMicroservice.Entities
{
    public class Stock
    {

        public int ProductId { get; set; }
        public int QuantityAvailable { get; set; }
        // public int QuantitySold { get; set; }
        public DateTime LastRestroed { get; set; }
        public DateTime LastUpdated { get; set; }

    }
}
