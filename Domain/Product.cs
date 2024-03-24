using Domain.Exceptions;
using System.Text.RegularExpressions;

namespace Domain;

public sealed class Product
{
    public Guid Id { get; private set; }
    public string Name { get; private set; } = null!;
    public string Description { get; private set; } = null!;
    public string ImageLink { get; private set; } = null!;
    public decimal Price { get; private set; }
    public int Quantity { get; private set; }
    
    private Product() {}

    public static Product Create(string name, string description, string imageLink, decimal price, int quantity)
    {
        var product = new Product
        {
            Id = Guid.NewGuid()
        };
        product.SetName(name);
        product.SetDescription(description);
        product.SetImageLink(imageLink);
        product.SetPrice(price);
        product.SetQuantity(quantity);
        return product;
    }

    public void SetName(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new NameMinLengthException();
        }
        
        if (name.Length > 120)
        {
            throw new NameMaxLengthException();
        }

        Name = name;
    }
    
    public void SetDescription(string description)
    {
        if (string.IsNullOrEmpty(description))
        {
            throw new DescriptionMinLengthException();
        }
        
        if (description.Length > 1000)
        {
            throw new DescriptionMaxLengthException();
        }

        Description = description;
    }
    
    public void SetImageLink(string imageLink)
    {
        var isCreatedUri = Uri.TryCreate(imageLink, UriKind.Absolute, out var imageLinkUri);
        if (!isCreatedUri || imageLinkUri == null)
        {
            throw new InvalidImageLinkException();
        }

        var availableSchemes = new List<string>
        {
                        Uri.UriSchemeHttp, Uri.UriSchemeHttps
        };
        
        if (availableSchemes.Contains(imageLinkUri.Scheme) == false)
        {
            throw new InvalidImageLinkException();
        }

        var isMatchExtension = Regex.IsMatch(imageLink, @"\.(jpeg|jpg|gif|png)$", RegexOptions.IgnoreCase);
        if (isMatchExtension == false)
        {
            throw new InvalidImageLinkException();
        }

        ImageLink = imageLink;
    }
    
    public void SetPrice(decimal price)
    {
        if (price <= 0)
        {
            throw new InvalidPriceException();
        }

        Price = price;
    }
    
    public void SetQuantity(int quantity)
    {
        if (quantity < 0)
        {
            throw new InvalidQuantityException();
        }

        Quantity = quantity;
    }
}
