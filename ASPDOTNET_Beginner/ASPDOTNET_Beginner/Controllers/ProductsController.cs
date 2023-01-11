using ASPDOTNET_Beginner.Models;
using ASPDOTNET_Beginner.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;

namespace ASPDOTNET_Beginner.Controllers {
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase 
    {
        public ProductsController(JsonFileProductService productService) {
            this.ProductService = productService;
        }
        public JsonFileProductService ProductService { get;}

        [HttpGet]
        public IEnumerable<Product> Get() {
            return ProductService.GetProducts();
        }
        //[]
        [Route("Rate")]
        [HttpGet]
        public ActionResult Get(
            [FromQuery] string ProductId,
            [FromQuery] int Rating) 
        {
            ProductService.AddRating(ProductId, Rating);
            return Ok();
        }
    }
}
