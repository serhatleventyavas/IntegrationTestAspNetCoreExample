using Domain;

namespace Application.Products.GetItem;

internal sealed class GetProductItemService(
    IProductRepository productRepository
    ): IGetProductItemService
{
    public async Task<Product> Handle(GetProductItemInput input)
    {
        var id = input.Id;
        return await productRepository.GetByIdAsync(id) 
               ?? throw new NullReferenceException(nameof(Product));
    }
}