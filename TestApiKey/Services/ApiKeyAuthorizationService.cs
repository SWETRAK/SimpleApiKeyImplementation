using TestApiKey.Services.Interfaces;

namespace TestApiKey.Services;

public class ApiKeyAuthorizationService(DomainDbContext context): IApiKeyAuthorizationService
{
    public async Task<bool> Validation()
    {
        return await Task.Run(() => true);
    }
}