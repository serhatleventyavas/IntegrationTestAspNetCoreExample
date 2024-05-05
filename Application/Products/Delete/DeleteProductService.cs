using Domain;

namespace Application.Products.Delete;

internal sealed class DeleteProductService(
    IUnitOfWork unitOfWork, 
    IProductRepository productRepository
    ): IDeleteProductService
{
    public async Task Handle(DeleteProductInput input)
    {
        var id = input.Id;
        
        var product = await productRepository.GetByIdAsync(id) 
               ?? throw new NullReferenceException(nameof(Product));

        productRepository.Delete(product);
        await unitOfWork.SaveChangesAsync();
    }
}