namespace Application.Products.Create;

public interface ICreateProductService
{
    Task<Guid> Handle(CreateProductInput input);
}