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
        => Ok(await _service.GetAll());

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
        => Ok(await _service.GetById(id));

    [HttpPost]
    public async Task<IActionResult> Create(Product product)
    {
        await _service.Add(product);
        return Ok(product);
    }

    [HttpPut]
    public async Task<IActionResult> Update(Product product)
    {
        await _service.Update(product);
        return Ok(product);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.Delete(id);
        return Ok();
    }
}