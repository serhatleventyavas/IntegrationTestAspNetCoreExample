using Domain;

namespace Application.Products.Create;

internal sealed class CreateProductService(
    IUnitOfWork unitOfWork, 
    IProductRepository productRepository
    ): ICreateProductService
{
    public async Task<Guid> Handle(CreateProductInput input)
    {
        var name = input.Name;
        var description = input.Description;
        var imageLink = input.ImageLink;
        var price = input.Price;
        var quantity = input.Quantity;

        var product = Product.Create(name, description, imageLink, price, quantity);
        await productRepository.AddAsync(product);
        await unitOfWork.SaveChangesAsync();

        return product.Id;
    }
}