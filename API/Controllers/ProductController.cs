using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ProductController : ControllerBase
{
    private readonly ProductService _service;

    public ProductController(ProductService service)
    {
        _service = service;
    }

    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var products = await _service.GetAll();

        if (products == null || !products.Any())
            return NoContent(); 

        return Ok(products);
    }

    
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var product = await _service.GetById(id);

        if (product == null)
            return NotFound(new { message = "Product not found" }); 

        return Ok(product); 
    }

    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Product product)
    {
        if (product == null)
            return BadRequest(new { message = "Invalid product data" }); 

        await _service.Add(product);

        return CreatedAtAction(
            nameof(Get),
            new { id = product.Id },
            product
        ); 
    }


    [HttpPut]
    public async Task<IActionResult> Update([FromBody] Product product)
    {
        if (product == null)
            return BadRequest(new { message = "Invalid product data" });

        var existing = await _service.GetById(product.Id);

        if (existing == null)
            return NotFound(new { message = "Product not found" });

        // ✅ Update existing object (IMPORTANT)
        existing.ProductName = product.ProductName;
        existing.ModifiedOn = DateTime.UtcNow;

        await _service.Update(existing);

        return Ok(new
        {
            message = "Product updated successfully",
            data = existing
        });
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var existing = await _service.GetById(id);

        if (existing == null)
            return NotFound(new { message = "Product not found" }); 

        await _service.Delete(id);

        return Ok(new { message = "Product deleted successfully" });
    }
}