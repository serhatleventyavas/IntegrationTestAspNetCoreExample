namespace Application.Products.Create;

public sealed record CreateProductInput
{
    public required string Name { get; set; } = null!;
    public required string Description { get; set; } = null!;
    public required string ImageLink { get; set; } = null!;
    public required decimal Price { get; set; }
    public required int Quantity { get; set; }
}