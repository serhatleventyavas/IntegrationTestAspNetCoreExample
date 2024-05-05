using Application.Products.Create;
using Application.Products.Delete;
using Application.Products.GetItem;
using Application.Products.GetList;
using Application.Products.Update;
using Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace Application.IntegrationTests;

public abstract class BaseIntegrationTest: IClassFixture<IntegrationTestWebAppFactory>
{
    protected readonly ApplicationDbContext DbContext;
    protected readonly ICreateProductService createProductService;
    protected readonly IUpdateProductService updateProductService;
    protected readonly IDeleteProductService deleteProductService;
    protected readonly IGetProductItemService getProductItemService;
    protected readonly IGetProductListService getProductListService;
    
    protected BaseIntegrationTest(IntegrationTestWebAppFactory factory)
    {
        var scope = factory.Services.CreateScope();
        DbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        createProductService = scope.ServiceProvider.GetRequiredService<ICreateProductService>();
        updateProductService = scope.ServiceProvider.GetRequiredService<IUpdateProductService>();
        deleteProductService = scope.ServiceProvider.GetRequiredService<IDeleteProductService>();
        getProductItemService = scope.ServiceProvider.GetRequiredService<IGetProductItemService>();
        getProductListService = scope.ServiceProvider.GetRequiredService<IGetProductListService>();
    }
}