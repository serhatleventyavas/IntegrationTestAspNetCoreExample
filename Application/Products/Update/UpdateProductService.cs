using Domain;

namespace Application.Products.Update;

internal sealed class UpdateProductService(
    IUnitOfWork unitOfWork, 
    IProductRepository productRepository
    ): IUpdateProductService
{
    public async Task<Product> Handle(UpdateProductInput input)
    {
        var id = input.Id;
        var name = input.Name;
        var description = input.Description;
        var imageLink = input.ImageLink;
        var price = input.Price;
        var quantity = input.Quantity;
        
        var product = await productRepository.GetByIdAsync(id) 
                      ?? throw new NullReferenceException(nameof(Product));
        
        product.SetName(name);
        product.SetDescription(description);
        product.SetImageLink(imageLink);
        product.SetPrice(price);
        product.SetQuantity(quantity);
        
        productRepository.Update(product);
        await unitOfWork.SaveChangesAsync();

        return product;
    }
}