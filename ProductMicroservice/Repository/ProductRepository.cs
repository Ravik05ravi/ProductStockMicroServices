using Microsoft.EntityFrameworkCore;
using ProductMicroservice.Data;
using ProductMicroservice.DTOs;
using ProductMicroservice.Entities;
using ProductMicroservice.ProductInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductMicroservice.Repository
{
    public class ProductRepository : IProduct
    {
        private readonly DataContext _dataContextClass;

        public ProductRepository(DataContext dataContextClass)
        {
            _dataContextClass = dataContextClass;
        }
        public async Task<int> AddProductAsync(Product product)
        {
            try
            {
               
                var ProductDto = new ProductDto
                {
                    Name = product.Name,
                    Brand = product.Brand,
                    //Category = product.Category,
                    //ImageUrl = product.ImageUrl,
                    Description = product.Description,
                    Price = product.Price,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now

                };


                await _dataContextClass.Product.AddAsync(ProductDto);
                await _dataContextClass.SaveChangesAsync();
                var result = 1;

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //return null;
        }

        public async Task<ProductDto> GetProduct(int id)
        {
            // var res = await _dataContextClass.Product.Where(o => o.ProductId == id);

            return null;
        }

        public async Task<List<ProductDto>> GetProductDetails()
        {
            return await _dataContextClass.Product.ToListAsync();

        }

        public async Task<List<ProductDto>> GetProductDtos()
        {
             return await _dataContextClass.Product.ToListAsync();

        }
    }
}
