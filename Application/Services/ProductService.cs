using Domain.Entities;

public class ProductService
{
    private readonly IProductRepository _repo;

    public ProductService(IProductRepository repo)
    {
        _repo = repo;
    }

    public async Task<List<Product>> GetAll()
        => await _repo.GetAll();

    public async Task<Product> GetById(int id)
    {
        var product = await _repo.GetById(id);

        if (product == null)
            throw new KeyNotFoundException($"Product with id {id} not found");

        return product;
    }

    public async Task Add(Product product)
    {
        if (product == null)
            throw new ArgumentException("Product cannot be null");

        product.CreatedOn = DateTime.Now;
        await _repo.Add(product);
    }

    public async Task Update(Product product)
    {
        if (product == null)
            throw new ArgumentException("Product cannot be null");

        var existing = await _repo.GetById(product.Id);

        if (existing == null)
            throw new KeyNotFoundException($"Product with id {product.Id} not found");

        product.ModifiedOn = DateTime.Now;
        await _repo.Update(product);
    }

    public async Task Delete(int id)
    {
        var product = await _repo.GetById(id);

        if (product == null)
            throw new KeyNotFoundException($"Product with id {id} not found");

        await _repo.Delete(product);
    }
}