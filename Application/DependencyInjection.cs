using Application.Products.Create;
using Application.Products.Delete;
using Application.Products.GetItem;
using Application.Products.GetList;
using Application.Products.Update;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<ICreateProductService, CreateProductService>();
        services.AddScoped<IUpdateProductService, UpdateProductService>();
        services.AddScoped<IDeleteProductService, DeleteProductService>();
        services.AddScoped<IGetProductListService, GetProductListService>();
        services.AddScoped<IGetProductItemService, GetProductItemService>();

        return services;
    }
}