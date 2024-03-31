using Domain;

namespace Application.Products.GetList;

internal sealed class GetProductListService(
    IProductRepository productRepository
    ): IGetProductListService
{
    public async Task<List<Product>> Handle()
    { 
        return await productRepository.GetListAsync();
    }
}