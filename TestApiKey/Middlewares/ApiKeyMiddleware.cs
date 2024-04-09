using TestApiKey.Services.Interfaces;

namespace TestApiKey.Middlewares;

public class ApiKeyMiddleware(IApiKeyAuthorizationService apiKeyAuthorizationService, DomainDbContext domainDbContext): IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        if (!context.Request.Headers.TryGetValue("X-API-KEY", out var apiKey))
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            await context.Response.WriteAsJsonAsync(string.Empty);
            return;
        }

        Console.WriteLine(domainDbContext.ContextId);
        Console.WriteLine(await apiKeyAuthorizationService.Validation());   
        Console.WriteLine(apiKey.ToString());
        
        // Add more validation statements
        
        await next.Invoke(context);
    }
}