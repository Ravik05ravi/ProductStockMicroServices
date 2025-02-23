using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductMicroservice.DTOs;
using ProductMicroservice.Entities;
using ProductMicroservice.ProductInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProduct _productRepository;
        private readonly IStock _productStock;

        public ProductController(IProduct productRepository, IStock productStock) =>
            (_productRepository, _productStock) = (productRepository, productStock);


        [HttpPost("AddProduct")]
        public async Task<ActionResult> AddProduct(Product product)
        {
            try
            {
                if (product == null)
                {
                    var errObj = new ErrorResponse(ErrorReason.validationFail.ToString(), StatusCodes.Status400BadRequest, "InValid Request Object");
                    return BadRequest(errObj);
                }

                var response = _productRepository.AddProductAsync(product);

                if (response.IsCompleted)
                {
                    var errObj = new ErrorResponse(ErrorReason.success.ToString(), StatusCodes.Status200OK, " Product Add Successfully");

                    return Ok(errObj);

                }
                else
                {
                    var errObj = new ErrorResponse(ErrorReason.internalError.ToString(), StatusCodes.Status500InternalServerError, " Product not added");

                    return Ok(errObj);

                }
            }
            catch (Exception ex)
            {
                var errObj = new ErrorResponse(ex.Message.ToString(), StatusCodes.Status500InternalServerError, "Internal Server Error");
                return BadRequest(errObj);

            }
            return null;

        }

        [HttpGet("GetlistProductinfo")]
        public async Task<ActionResult> GetlistProduct()
        {
            try
            {
             
                return Ok(await _productRepository.GetProductDtos());

            }
            catch (Exception ex)
            {

            }
            return null;

        }

        [HttpGet("GetProductinfo/{id}")]
        public async Task<ActionResult> GetProduct(int id)
        {
            try
            {
                return Ok(await _productRepository.GetProduct(id));

            }
            catch (Exception ex)
            {

            }
            return null;

        }

        [HttpPut("UpdateProduct/{id}")]
        public async Task<ActionResult> UpdateProduct(Product product)
        {
            try
            {


            }
            catch (Exception ex)
            {

            }
            return null;

        }

        [HttpDelete("DeleteProduct/{id}")]
        public async Task<ActionResult> DeleteProduct()
        {
            try
            {

            }
            catch (Exception ex)
            {

            }
            return null;

        }
        [HttpPut("decrement-stock/{id}/{quantity}")]
        public async Task<ActionResult> DecrementStockQuatity(int Productid, [FromBody] RequestIncreaseorDecreaseStockquantity requestIncreaseorDecreaseStockquantity)
        {
            try
            {


            }
            catch (Exception ex)
            {

            }
            return null;
        }

        [HttpPut("add-to-stock/{id}/{quantity}")]
        public async Task<ActionResult> AddStockQuatity(int Productid, [FromBody] RequestIncreaseorDecreaseStockquantity requestIncreaseorDecreaseStockquantity)
        {
            try
            {

            }
            catch (Exception ex)
            {

            }
            return null;
        }

    }
}
