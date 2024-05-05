using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public sealed class ProductRepository(ApplicationDbContext dbContext): IProductRepository
{
    public async Task AddAsync(Product product)
    {
        await dbContext.AddAsync(product);
    }

    public void Update(Product product)
    {
        dbContext.Update(product);
    }

    public void Delete(Product product)
    {
        dbContext.Remove(product);
    }

    public async Task<Product?> GetByIdAsync(Guid id)
    {
        return await dbContext.Set<Product>().FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<List<Product>> GetListAsync()
    {
        return await dbContext.Set<Product>().ToListAsync();
    }
}