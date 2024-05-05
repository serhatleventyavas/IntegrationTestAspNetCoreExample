namespace Application.Products.GetItem;

public sealed record GetProductItemInput
{
    public required Guid Id { get; set; }
}