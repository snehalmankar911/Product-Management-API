using Microsoft.EntityFrameworkCore;
using Infrastructure.Data;
using Domain.Entities;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _context;

    public ProductRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Product>> GetAll()
        => await _context.Products.AsNoTracking().ToListAsync();

    public async Task<Product> GetById(int id)
        => await _context.Products.FindAsync(id);

    public async Task Add(Product product)
    {
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
    }

    public async Task Update(Product product)
    {
        _context.Products.Update(product);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(Product product)
    {
        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
    }
}