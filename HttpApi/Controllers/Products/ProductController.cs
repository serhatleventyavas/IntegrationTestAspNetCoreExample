using Application.Products.Create;
using Application.Products.Delete;
using Application.Products.GetItem;
using Application.Products.GetList;
using Application.Products.Update;
using Domain;
using HttpApi.Controllers.Products.RequestBodies;
using Microsoft.AspNetCore.Mvc;

namespace HttpApi.Controllers.Products;

[ApiController]
[Route("api/products")]
public sealed class ProductController
    (
        ICreateProductService createProductService,
        IUpdateProductService updateProductService,
        IDeleteProductService deleteProductService,
        IGetProductItemService getProductItemService,
        IGetProductListService getProductListService): ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<Guid>> CreateAsync([FromBody] CreateProductRequestBody requestBody)
    {
        var result = await createProductService.Handle(new CreateProductInput
        {
            Description = requestBody.Description,
            Name = requestBody.Name,
            Price = requestBody.Price,
            Quantity = requestBody.Quantity,
            ImageLink = requestBody.ImageLink
        });
        return CreatedAtAction(nameof(GetItemAsync), new { id = result }, result);
    }
    
    [HttpPut(template: "{id:guid}")]
    public async Task<ActionResult<Product>> UpdateAsync(Guid id, [FromBody] UpdateProductRequestBody requestBody)
    {
        var result = await updateProductService.Handle(new UpdateProductInput
        {
            Id = id,
            Description = requestBody.Description,
            Name = requestBody.Name,
            Price = requestBody.Price,
            Quantity = requestBody.Quantity,
            ImageLink = requestBody.ImageLink
        });
        return Ok(result);
    }
    
    [HttpDelete(template: "{id:guid}")]
    public async Task<ActionResult> DeleteAsync(Guid id)
    {
        await deleteProductService.Handle(new DeleteProductInput
        {
            Id = id
        });
        return NoContent();
    }
    
    [HttpGet(template: "{id:guid}")]
    public async Task<ActionResult<Product>> GetItemAsync(Guid id)
    {
        var result = await getProductItemService.Handle(new GetProductItemInput
        {
            Id = id
        });

        return Ok(result);
    }
    
    [HttpGet]
    public async Task<ActionResult<List<Product>>> GetListAsync()
    {
        var result = await getProductListService.Handle();
        return Ok(result);
    }
}