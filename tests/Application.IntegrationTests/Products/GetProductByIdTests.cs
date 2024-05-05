using Application.Products.GetItem;
using Domain;

namespace Application.IntegrationTests.Products;

public sealed class GetProductByIdTests(IntegrationTestWebAppFactory factory): BaseIntegrationTest(factory)
{
    [Fact]
    public async Task Should_Get_Product()
    {
        var product = Product.Create(
            name: "IPhone 15 Pro",
            description: "IPhone telefon",
            imageLink: "https://s3.superproducts.com/iphone-15-pro.png",
            price: 100_000,
            quantity: 100);
        
        await DbContext.Set<Product>().AddAsync(product);
        await DbContext.SaveChangesAsync();

        var result = await getProductItemService.Handle(new GetProductItemInput
        {
            Id = product.Id
        });

        Assert.NotNull(product);
        Assert.IsType<Product>(product);
        Assert.Equal(product.Id, result.Id);
    }
}