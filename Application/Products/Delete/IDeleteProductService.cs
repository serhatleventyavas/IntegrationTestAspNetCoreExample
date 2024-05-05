namespace Application.Products.Delete;

public interface IDeleteProductService
{
    Task Handle(DeleteProductInput input);
}