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
                //Need to change the Details Add Stock quantity when we are registering the  product to admin
                if (product == null)
                {
                    var errObj = new ErrorResponse(ErrorReason.validationFail.ToString(), StatusCodes.Status400BadRequest, "InValid Request Object");
                    return BadRequest(errObj);
                }

                var response =await _productRepository.AddProductAsync(product);

                if (response>0)
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
                return StatusCode(500,ex.Message.ToString()+" Error: "+errObj);

            }
           

        }

        [HttpGet("GetlistProductinfo")]
        public async Task<ActionResult> GetlistProduct()
        {
            try
            {

                var response = await _productRepository.GetProductDtos();

                if (response == null)
                {
                    var errObj = new ErrorResponse(ErrorReason.noContent.ToString(), StatusCodes.Status404NotFound, " No Product is available ");
                    return BadRequest(errObj);

                }

                return Ok(response);

            }
            catch (Exception ex)
            {
                var errObj = new ErrorResponse(ex.Message.ToString(), StatusCodes.Status500InternalServerError, "Internal Server Error");
                return StatusCode(500, ex.Message.ToString() + " Error: " + errObj);

            }
           
        }

        [HttpGet("GetProductinfo/{id}")]
        public async Task<ActionResult> GetProduct(int id)
        {
            try
            {
                if (id <= 0)
                {
                    var errObj = new ErrorResponse(ErrorReason.validationFail.ToString(), StatusCodes.Status400BadRequest, " Incorrect Product id");
                    return BadRequest(errObj);

                }
                var response = await _productRepository.GetProduct(id);

                if(response==null)
                {
                    var errObj = new ErrorResponse(ErrorReason.noContent.ToString(), StatusCodes.Status404NotFound, " No Product is available or Incorrect Product id");
                    return BadRequest(errObj);

                }
                return Ok(response);

            }
            catch (Exception ex)
            {
                var errObj = new ErrorResponse(ex.Message.ToString(), StatusCodes.Status500InternalServerError, "Internal Server Error");
                return StatusCode(500, ex.Message.ToString() + " Error: " + errObj);

            }
           

        }

        [HttpPut("UpdateProduct/{id}")]
        public async Task<ActionResult> UpdateProduct( [FromBody] int id,Product product)
        {
            try
            {
                if (id <= 0 && product == null || id <= 0 || product == null)
                {
                    var errObj = new ErrorResponse(ErrorReason.validationFail.ToString(), StatusCodes.Status400BadRequest, "InValid Request Object");
                    return BadRequest(errObj);
                }

                var res = await _productRepository.UpdateProduct(id,product);

                if(res>0)
                {
                    var obj =new ErrorResponse(ErrorReason.success.ToString(), StatusCodes.Status200OK, " Product details updated succssfully");
                    return StatusCode(200, obj);
                }
                else
                {
                    var obj = new ErrorResponse(ErrorReason.internalError.ToString(), StatusCodes.Status500InternalServerError, " Product details not updated ");
                    return StatusCode(500,obj);
                }

            }
            catch (Exception ex)
            {
                var errObj = new ErrorResponse(ex.Message.ToString(), StatusCodes.Status500InternalServerError, "Internal Server Error");
                return StatusCode(500, ex.Message.ToString() + " Error: " + errObj);
            }
           

        }

        [HttpDelete("DeleteProduct/{id}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            try
            {
                if (id <= 0)
                {
                    var errObj = new ErrorResponse(ErrorReason.validationFail.ToString(), StatusCodes.Status400BadRequest, "InValid Request Object");
                    return BadRequest(errObj);
                }
                var response = await _productRepository.DeleteProduct(id);

                if(response>0)
                {
                    var obj = new ErrorResponse(ErrorReason.success.ToString(), StatusCodes.Status204NoContent, " Product details deleted succssfully");
                    return StatusCode(204, obj);
                }
                else
                {
                    var obj = new ErrorResponse(ErrorReason.internalError.ToString(), StatusCodes.Status500InternalServerError, " Product id or details not valid ");
                    return StatusCode(500, obj);
                }
            }
            catch (Exception ex)
            {
                var errObj = new ErrorResponse(ex.Message.ToString(), StatusCodes.Status500InternalServerError, "Internal Server Error");
                return StatusCode(500, ex.Message.ToString() + " Error: " + errObj);
            }
        }
        [HttpPut("decrement-stock/{id}/{quantity}")]
        public async Task<ActionResult> DecrementStockQuatity(int ProductStockid, [FromBody] RequestIncreaseorDecreaseStockquantity requestIncreaseorDecreaseStockquantity)
        {
            try
            {
                if (ProductStockid <= 0 && requestIncreaseorDecreaseStockquantity == null || ProductStockid <= 0 || requestIncreaseorDecreaseStockquantity == null)
                {
                    var errObj = new ErrorResponse(ErrorReason.validationFail.ToString(), StatusCodes.Status400BadRequest, "InValid Request Object");
                    return BadRequest(errObj);
                }

                var res = await _productStock.DecrementProductStockQuatity(ProductStockid, requestIncreaseorDecreaseStockquantity);

                if (res > 0)
                {
                    var obj = new ErrorResponse(ErrorReason.success.ToString(), StatusCodes.Status205ResetContent, " Product Stock details updated succssfully");
                    return StatusCode(200, obj);
                }
                else
                {
                    var obj = new ErrorResponse(ErrorReason.internalError.ToString(), StatusCodes.Status500InternalServerError, " Product Stock details not updated ");
                    return StatusCode(500, obj);
                }

            }
            catch (Exception ex)
            {
                var errObj = new ErrorResponse(ex.Message.ToString(), StatusCodes.Status500InternalServerError, "Internal Server Error");
                return StatusCode(500, ex.Message.ToString() + " Error: " + errObj);

            }
           
        }

        [HttpPut("add-to-stock/{id}/{quantity}")]
        public async Task<ActionResult> AddStockQuatity(int ProductStockid=0, [FromBody] RequestIncreaseorDecreaseStockquantity requestIncreaseorDecreaseStockquantity)
        {
            try
            {
                if (ProductStockid <= 0 && requestIncreaseorDecreaseStockquantity == null || ProductStockid <= 0 || requestIncreaseorDecreaseStockquantity == null)
                {
                    var errObj = new ErrorResponse(ErrorReason.validationFail.ToString(), StatusCodes.Status400BadRequest, "InValid Request Object");
                    return BadRequest(errObj);

                }

                var res = await _productStock.AddProductStockQuatity(ProductStockid, requestIncreaseorDecreaseStockquantity);

                if (res > 0)
                {
                    var obj = new ErrorResponse(ErrorReason.success.ToString(), StatusCodes.Status200OK, " Product Stock details updated succssfully");

                    return StatusCode(200, obj);

                }
                else
                {
                    var obj = new ErrorResponse(ErrorReason.internalError.ToString(), StatusCodes.Status500InternalServerError, " Product Stock details not updated ");
                    return StatusCode(500, obj);

                }


            }
            catch (Exception ex)
            {
                var errObj = new ErrorResponse(ex.Message.ToString(), StatusCodes.Status500InternalServerError, "Internal Server Error");
                return StatusCode(500, ex.Message.ToString() + " Error: " + errObj);

            }
           
        }

    }
}
