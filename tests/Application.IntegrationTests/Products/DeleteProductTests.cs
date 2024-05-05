using Application.Products.Delete;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.IntegrationTests.Products;

public sealed class DeleteProductTests(IntegrationTestWebAppFactory factory): BaseIntegrationTest(factory)
{
    [Fact]
    public async Task Should_Delete_Product()
    {
        var product = Product.Create(
            name: "IPhone 15 Pro", 
            description: "IPhone telefon", 
            imageLink: "https://s3.superproducts.com/iphone-15-pro.png", 
            price: 100_000,
            quantity: 100);
        
        await DbContext.Set<Product>().AddAsync(product);
        await DbContext.SaveChangesAsync();
        
        var input = new DeleteProductInput
        {
            Id = product.Id
        };

        await deleteProductService.Handle(input);

        var deletedProduct = await DbContext.Set<Product>().FirstOrDefaultAsync(p => p.Id == input.Id);
        Assert.Null(deletedProduct);
    }
}