using ProductMicroservice.DTOs;
using ProductMicroservice.ProductInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductMicroservice.Repository
{
        public class ProductStockRepository : IStock
        {
            public Task<List<ProductDto>> AddProductStockQuatity()
            {
                throw new NotImplementedException();
            }

            public Task<List<ProductDto>> DecrementProductStockQuatity()
            {
                throw new NotImplementedException();
            }
        }
}
