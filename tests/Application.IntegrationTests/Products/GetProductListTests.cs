using Domain;

namespace Application.IntegrationTests.Products;

public sealed class GetProductListTests(IntegrationTestWebAppFactory factory): BaseIntegrationTest(factory)
{
    [Fact]
    public async Task Should_Get_Product_List()
    {
        await DbContext.Set<Product>().AddRangeAsync(
            [
                Product.Create(
                    name: "IPhone 15", 
                    description: "IPhone telefon", 
                    imageLink: "https://s3.superproducts.com/iphone-15.png", 
                    price: 80_000,
                    quantity: 100),
                Product.Create(
                    name: "IPhone 15 Plus", 
                    description: "IPhone telefon", 
                    imageLink: "https://s3.superproducts.com/iphone-15-plus.png", 
                    price: 90_000,
                    quantity: 100),
                Product.Create(
                    name: "IPhone 15 Pro", 
                    description: "IPhone telefon", 
                    imageLink: "https://s3.superproducts.com/iphone-15-pro.png", 
                    price: 100_000,
                    quantity: 100)
            ]
        );
        await DbContext.SaveChangesAsync();

        var products = await getProductListService.Handle();
        Assert.NotNull(products);
        Assert.IsType<List<Product>>(products);
        Assert.Equal(3, products.Count);
    }
}