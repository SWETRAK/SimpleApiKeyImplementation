using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using TestApiKey.Services.Interfaces;

namespace TestApiKey.Attributes;

public class ApiKeyAuthorizeAttribute: ActionFilterAttribute
{
    public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var apiKeyAuthorizationService = context.HttpContext.RequestServices.GetService<IApiKeyAuthorizationService>();
        await using var domainDbContext = context.HttpContext.RequestServices.GetService<DomainDbContext>(); // DbContext can be accessed in attribute
        if (apiKeyAuthorizationService is null || domainDbContext is null)
        {
            throw new ApplicationException();
        }
        
        if (!context.HttpContext.Request.Headers.TryGetValue("X-API-KEY", out var apiKey))
        {
            context.Result = new UnauthorizedResult();
            return;
        }

        Console.WriteLine(domainDbContext.ContextId);
        Console.WriteLine(await apiKeyAuthorizationService.Validation());   
        Console.WriteLine(apiKey.ToString());
        
        // Add more validation statements
        
        await base.OnActionExecutionAsync(context, next);
    }
}