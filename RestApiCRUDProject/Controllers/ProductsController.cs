using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestApiCRUDProject.Models;
using RestApiCRUDProject.ProductsData;
using System.Collections.Generic;

namespace RestApiCRUDProject.Controllers
{
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductsData productData;
        public ProductsController(IProductsData productData)
        {
            this.productData = productData;
        }

        /// <summary>
        /// gets all the products
        /// </summary>
        /// <returns> list of products</returns>
        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetProducts() 
        {
            return Ok(productData.GetProducts());
        }

        /// <summary>
        /// gets the product with a matching product Id
        /// </summary>
        /// <param name="productId"></param>
        /// <returns>single product </returns>
        [HttpGet]
        [Route("api/[controller]/{productId}")]
        public IActionResult GetProduct(int productId)
        {
            var product = productData.GetProduct(productId);
            if(product != null)
            {
                return Ok(product);
            }
            return NotFound($"Product with Id: {productId} was not found");
        }

        /// <summary>
        /// Adds a single product
        /// </summary>
        /// <param name="product"></param>
        /// <returns>Added product</returns>
        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult GetProduct(Product product)
        {
            productData.AddProduct(product);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + product.ProductId, product);
        }

        /// <summary>
        /// Removed product based on the product Id
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("api/[controller]/{productId}")]
        public IActionResult DeleteProduct(int productId)
        {
            var product = productData.GetProduct(productId);
            if (product != null)
            {
                productData.DeleteProduct(product);
                return Ok();
            }
            return NotFound($"Product with Id: {productId} was not found");
        }

        /// <summary>
        /// based on the product Id provided and product info, endpoint updates the product
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPatch]
        [Route("api/[controller]/{productId}")]
        public IActionResult EditProduct(int productId, Product product)
        {
            var existingProduct = productData.GetProduct(productId);
            if (existingProduct != null)
            {
                product.ProductId = productId;
                productData.EditProduct(product);
                return Ok(product);
            }
            return NotFound($"Product with Id: {productId} was not found");
        }
    }
}
