namespace Domain;

public interface IProductRepository
{
    Task AddAsync(Product product);
    void Update(Product product);
    void Delete(Product product);
    Task<Product> GetByIdAsync(Guid id);
    Task<List<Product>> GetListAsync();
}