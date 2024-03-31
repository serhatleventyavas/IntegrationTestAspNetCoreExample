using Domain;

namespace Application.Products.GetItem;

public interface  IGetProductItemService
{
    Task<Product> Handle(GetProductItemInput input);
}