namespace Application.Products.Delete;

public sealed record DeleteProductInput
{
    public required Guid Id { get; set; }
}