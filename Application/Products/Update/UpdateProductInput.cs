namespace Application.Products.Update;

public sealed record UpdateProductInput
{
    public required Guid Id { get; set; }
    public required string Name { get; set; } = null!;
    public required string Description { get; set; } = null!;
    public required string ImageLink { get; set; } = null!;
    public required decimal Price { get; set; }
    public required int Quantity { get; set; }
}