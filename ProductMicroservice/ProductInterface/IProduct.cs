using ProductMicroservice.DTOs;
using ProductMicroservice.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductMicroservice.ProductInterface
{
   public interface IProduct
    {
        Task<List<ProductDto>> GetProductDtos();

        Task<ProductDto> GetProduct(int id);

        Task<int> AddProductAsync(Product product);

    }
}
