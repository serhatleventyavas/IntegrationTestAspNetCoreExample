using Application.Products.Create;

namespace Application.IntegrationTests.Products;

public sealed class CreateProductTests(IntegrationTestWebAppFactory factory): BaseIntegrationTest(factory)
{
    [Fact]
    public async Task Should_Create_Product()
    {
        var input = new CreateProductInput
        {
            Name = "IPhone 15 Pro",
            Description = "IPhone telefon",
            Price = 100_000,
            Quantity = 100,
            ImageLink = "https://s3.superproducts.com/iphone-15-pro.png"
        };

        var result = await createProductService.Handle(input);
        Assert.IsType<Guid>(result);
        Assert.NotEqual(Guid.Empty, result);
    }
}