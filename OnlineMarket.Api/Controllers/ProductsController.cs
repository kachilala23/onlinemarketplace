using Microsoft.AspNetCore.Mvc;
using OnlineMarket.Api.Interface;
using OnlineMarket.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMarket.Api.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly ISeeder _seeder;
        public ProductsController(ISeeder seeder)
        {
            _seeder = seeder;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            var products = _seeder.GetAllProducts();
            return Ok(products);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetProductById(int id)
        {
            var product = _seeder.GetAllProducts().FirstOrDefault(p => p.Id == id);
            if (product == null)
                return BadRequest();
            return Ok(product);
        }

        [HttpPost]
        public IActionResult CreateProduct([FromBody] Product product)
        {
            var addResult = _seeder.AddProduct(product);
            if (!addResult)
            {
                return BadRequest("Product was not added. Please contact admin");
            }
            return Created("https://localhost:5001/api/products/{product.id}", product); 
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateProduct([FromBody] Product updatedProduct, int id)
        {
            var updateResult = _seeder.UpdateProduct(id, updatedProduct);
            if (updateResult)
                return Ok("Product was updated successfully");
            return BadRequest("Could not update product please try again");
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var deleteResult = _seeder.DeleteProduct(id);
            if (deleteResult)
                return Ok("Product was Deleted");
            
            return BadRequest("Cant delete product");            

        }




    }
}
