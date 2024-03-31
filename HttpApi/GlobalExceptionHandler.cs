using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Diagnostics;

namespace HttpApi;

internal sealed class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        logger.LogError(
            exception, "Exception occurred: {Message}", exception.Message);
        
        httpContext.Response.ContentType = "application/json";

        httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
        var jsonString = JsonSerializer.Serialize(new
        {
            StatusCode = StatusCodes.Status400BadRequest,
            Message = "Bir hata oluştu"
        });
        var jsonBytes = Encoding.UTF8.GetBytes(jsonString);
        await httpContext.Response.Body.WriteAsync(jsonBytes, cancellationToken);
        
        return true;
    }
}