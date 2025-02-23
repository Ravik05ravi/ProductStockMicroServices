using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductMicroservice.DTOs
{
    public class StockDto
    {
        [Key]

        public int StockId { get; set; }
        public int ProductId { get; set; }
        public int QuantityAvailable { get; set; }
       // public int QuantitySold { get; set; }
        public DateTime LastRestroed { get; set; }
        public DateTime LastUpdated { get; set; }

    }
}
