using Domain;

namespace Application.Products.Update;

public interface  IUpdateProductService
{
    Task<Product> Handle(UpdateProductInput input);
}