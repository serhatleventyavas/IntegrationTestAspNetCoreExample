using Application.Products.Update;
using Domain;

namespace Application.IntegrationTests.Products;

public sealed class UpdateProductTests(IntegrationTestWebAppFactory factory): BaseIntegrationTest(factory)
{
    [Fact]
    public async Task Should_Update_Product()
    {
        var product = Product.Create(
            name: "IPhone 15 Pro", 
            description: "IPhone telefon", 
            imageLink: "https://s3.superproducts.com/iphone-15-pro.png", 
            price: 100_000,
            quantity: 100);
        
        await DbContext.Set<Product>().AddAsync(product);
        await DbContext.SaveChangesAsync();
        
        var input = new UpdateProductInput
        {
            Id = product.Id,
            Name = "Updated IPhone 15 Pro",
            Description = "Updated IPhone telefon",
            Price = 125_000,
            Quantity = 80,
            ImageLink = "https://s3.superproducts.com/updated-iphone-15-pro.png"
        };

        var result = await updateProductService.Handle(input);
        Assert.NotNull(result);
        Assert.IsType<Product>(result);
        Assert.Equal(input.Id, result.Id);
        Assert.Equal(input.Name, result.Name);
        Assert.Equal(input.Description, result.Description);
        Assert.Equal(input.Price, result.Price);
        Assert.Equal(input.Quantity, result.Quantity);
        Assert.Equal(input.ImageLink, result.ImageLink);
    }
}