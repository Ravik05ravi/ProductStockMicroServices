using Microsoft.EntityFrameworkCore;
using ProductMicroservice.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductMicroservice.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions options): base(options)
        {

        }
        public DbSet<ProductDto> Product { get; set; }
        public DbSet<StockDto> Stock { get; set; }
    }
}
