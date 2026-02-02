using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVP_scope_e_shop_API.Data;
using MVP_scope_e_shop_API.Models;

namespace MVP_scope_e_shop_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly MVPScopeEshopApiContext _context;
        public ProductController(MVPScopeEshopApiContext context)
        {
            _context = context; 
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetShirts()
        {
            return Ok(await _context.Products.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetShirtById(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
                return NotFound();
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<Product>> AddShirt(Product newProduct)
        {
            if (newProduct == null)
                return BadRequest();
            _context.Products.Add(newProduct);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetShirtById), new { id = newProduct.Id }, newProduct);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, Product updatedProduct)
        {
            var product = await _context.Products.FindAsync(id);
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

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
                return NotFound();

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }


    }
}
