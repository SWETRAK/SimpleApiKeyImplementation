namespace TestApiKey.Services.Interfaces;

public interface IApiKeyAuthorizationService
{
    Task<bool> Validation();
}