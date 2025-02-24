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
           
        }

       

        public async Task<ProductDto> GetProduct(int id)
        {
            var res = await _dataContextClass.Product.Where(o=>o.ProductId==id).Select(p=> new ProductDto 
            {
                ProductId=p.ProductId,
                Name=p.Name,
                Brand=p.Brand,
                Catagory=p.Catagory,
                Description=p.Description,
                Price=p.Price,
                CreatedAt=p.CreatedAt,
                UpdatedAt=p.UpdatedAt
            
            }).FirstOrDefaultAsync();

            return res;
        }
        public async Task<List<ProductDto>> GetProductDtos()
        {
             return await _dataContextClass.Product.ToListAsync();

        }

        public async Task<int> UpdateProduct(int id, Product updatedProduct)
        {
            var product = await _dataContextClass.Product.FindAsync(id);

            if (product != null)
            {
                if (!string.IsNullOrEmpty(updatedProduct.Name))
                    product.Name = updatedProduct.Name;
                if (!string.IsNullOrEmpty(updatedProduct.Description))
                    product.Description = updatedProduct.Description;
                if (updatedProduct.Price > 0)
                    product.Price = updatedProduct.Price;
                if (!string.IsNullOrEmpty(updatedProduct.Brand))
                    product.Brand = updatedProduct.Brand;
                if (!string.IsNullOrEmpty(updatedProduct.Catagory))
                    product.Catagory = updatedProduct.Catagory;
                product.UpdatedAt = DateTime.Now;
                var res = await _dataContextClass.SaveChangesAsync();

                return res;
            }
            else
            {
                return 0;
            }
        }

        public async Task<int> DeleteProduct(int id)
        {
            var product = await _dataContextClass.Product.FindAsync(id);

            if (product != null)
            {

                _dataContextClass.Product.Remove(product);

                var res=await _dataContextClass.SaveChangesAsync();

                return res;
            }
            else
            {
                return 0;
            }

        }
    }
}
