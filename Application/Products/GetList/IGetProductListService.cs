using Domain;

namespace Application.Products.GetList;

public interface  IGetProductListService
{
    Task<List<Product>> Handle();
}