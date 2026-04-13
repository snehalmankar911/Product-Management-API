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
        => await _repo.GetById(id);

    public async Task Add(Product product)
    {
        product.CreatedOn = DateTime.Now;
        await _repo.Add(product);
    }

    public async Task Update(Product product)
    {
        product.ModifiedOn = DateTime.Now;
        await _repo.Update(product);
    }

    public async Task Delete(int id)
    {
        var product = await _repo.GetById(id);
        await _repo.Delete(product);
    }
}