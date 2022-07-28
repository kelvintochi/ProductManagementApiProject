using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductManagementApi.Data;
using ProductManagementApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ProductManagementApi.Controllers
{    
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public ProductController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        

        [HttpPost("create-product")]
        public IActionResult CreateProduct([FromBody] Product model)
        {

            var response = new ResponseModel<Product>();

            if (!ModelState.IsValid)
            {
                response.Success = false;
                response.StatusCode = HttpStatusCode.BadRequest;
                response.Message = "Required fields are not completed";
                return BadRequest(response);
            }
                response.Success = true;
                response.StatusCode = HttpStatusCode.OK;

                _applicationDbContext.Products.Add(model);
                _applicationDbContext.SaveChanges();
                response.Data = model;
                return Ok(response);
            }      
            
        

        [HttpGet("get-product")]
        public IActionResult GetProduct()
        {
            var products = _applicationDbContext.Products.ToList();
            var response = new ResponseModel<List<Product>>();
            response.Success = true;
            response.StatusCode = HttpStatusCode.OK;
            response.Message = "successful";
            response.Data = products;
            return Ok(response);
        }




        [HttpDelete("deleteproduct/{productId}")]
        public IActionResult DeleteProduct (int productId)
        {
            var product = _applicationDbContext.Products.Where(x => x.Id == productId).FirstOrDefault();

            if (product != null)
            {
                var response = new ResponseModel<Product>();
                _applicationDbContext.Products.Remove(product);

                _applicationDbContext.SaveChangesAsync();
                response.Message = "Deleted Successfully";
                return Ok(response);

            }
            return BadRequest(Response);
        }


        [HttpPost("update")]
        public IActionResult UpdateProduct(string productName)
        {
            var response = new ResponseModel<Product>();

            var product = _applicationDbContext.Products.Find(productName);
            if (product != null)
            {
                product.Name = productName;
                _applicationDbContext.SaveChanges();
                response.Message = "Updated Succesfully";
                return Ok(product);
            }
            else
            {
                response.Success = false;
                response.Message = "Not Successful";
                return BadRequest(Response);
            }


        }
        
        }
    }

