using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVP_scope_e_shop_API.Models;

namespace MVP_scope_e_shop_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        static private List<Product> products = new List<Product>
            {
            new Product {Id=1, Name="T-shirt", Brand="Love Mountains", Color="Red", Size=2, Gender="uni", Price=250, Description="100% wool"},
            new Product {Id=2, Name="Pants", Brand="Love Mountains", Color="Blue", Size=4, Gender="male", Price=590, Description=""}
            };

        [HttpGet]
        public ActionResult<List<Product>> GetShirts()
        { 
            return Ok(products); 
        }

        [HttpGet("{id}")]
        public ActionResult<Product> GetShirtById(int id)
        { 
            var product = products.FirstOrDefault(x=> x.Id == id);
            if (product == null)
                return NotFound();
            return Ok(product);
        }

        [HttpPost]
        public ActionResult<Product> AddShirt(Product newProduct)
        {
            if (newProduct == null)
                return BadRequest();
            products.Add(newProduct);
            return CreatedAtAction(nameof(GetShirtById), new { id = newProduct.Id }, newProduct);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, Product updatedProduct)
        {
            var product = products.FirstOrDefault(x => x.Id == id);
            if (product == null)
                return NotFound();

            product.Id = updatedProduct.Id;
            product.Name = updatedProduct.Name;
            product.Brand = updatedProduct.Brand;
            product.Color = updatedProduct.Color;
            product.Size = updatedProduct.Size;
            product.Gender = updatedProduct.Gender;
            product.Price = updatedProduct.Price;
            product.Description = updatedProduct.Description;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id) 
        {
            var product = products.FirstOrDefault(x => x.Id == id);
            if (product == null)
                return NotFound();

            products.Remove(product);
            return NoContent();
        }


    }
}
