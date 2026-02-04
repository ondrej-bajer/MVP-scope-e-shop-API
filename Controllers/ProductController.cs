using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVP_scope_e_shop_API.Data;
using MVP_scope_e_shop_API.Models;
using MVP_scope_e_shop_API.Mapping;
using MVP_scope_e_shop_API.Dtos.Products;

namespace MVP_scope_e_shop_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {

        private readonly MVPScopeEshopApiContext _context;
        public ProductController(MVPScopeEshopApiContext context)
        {
            _context = context; 
        }

        /// <summary>
        /// Return back all products
        /// </summary>
        /// <returns>List of ProductDto objects</returns>
        [HttpGet]
        public async Task<ActionResult<List<ProductDto>>> GetProducts()
        {
            var products = await _context.Products
                .AsNoTracking()
                .Select(p => p.ToDto())
                .ToListAsync();

            return Ok(products);
        }

        /// <summary>
        /// Return specific product based on id
        /// </summary>
        /// <param name="id">Product identifier (positive integer).</param>
        /// <response code="200">Product found</response>
        /// <response code="400">Invalid id</response>
        /// <response code="404">Product not found</response>
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductDto>> GetProductById(int id)
        {
            if (id <= 0)
                return BadRequest("Id must be a positive integer.");

            var productDto = await _context.Products
                .AsNoTracking()
                .Where(p => p.Id == id)
                .Select(p => p.ToDto())
                .FirstOrDefaultAsync();

            if (productDto == null)
                return NotFound();

            return Ok(productDto);
        }

        /// <summary>
        /// Creates a new product.
        /// </summary>
        /// <param name="dto">The product data to create.</param>
        /// <returns>The created product with assigned ID.</returns>
        /// <response code="201">Product successfully created.</response>
        /// <response code="400">Validation failed.</response>
        [HttpPost]
        public async Task<ActionResult<ProductDto>> AddProduct([FromBody] CreateProductDto dto)
        {
            var entity = dto.ToEntity();

            _context.Products.Add(entity);
            await _context.SaveChangesAsync();

            var resultDto = entity.ToDto();

            return CreatedAtAction(
                nameof(GetProductById),
                new { id = entity.Id },
                resultDto
            );
        }

        /// <summary>
        /// Updates an existing product by its ID.
        /// </summary>
        /// <param name="id">The ID of the product to update (positive integer).</param>
        /// <returns>The updated product.</returns>
        /// <response code="200">Product successfully updated.</response>
        /// <response code="400">Invalid ID or validation failed.</response>
        /// <response code="404">Product not found.</response>
        [HttpPut("{id:int}")]
        public async Task<ActionResult<ProductDto>> UpdateProduct(int id, [FromBody] UpdateProductDto dto)
        {
            if (id <= 0)
                return BadRequest("Id must be a positive integer.");

            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (product == null)
                return NotFound();

            dto.Apply(product);
            await _context.SaveChangesAsync();

            return Ok(product.ToDto());
        }

        /// <summary>
        /// Deletes a specific product by its ID.
        /// </summary>
        /// <param name="id">The ID of the product to delete (positive integer).</param>
        /// <response code="204">Product successfully deleted.</response>
        /// <response code="400">Invalid ID.</response>
        /// <response code="404">Product not found.</response>
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            if (id <= 0)
                return BadRequest("Id must be a positive integer.");

            var deleted = await _context.Products
                .Where(p => p.Id == id)
                .ExecuteDeleteAsync();

            if (deleted == 0)
                return NotFound();

            return NoContent();
        }


    }
}
