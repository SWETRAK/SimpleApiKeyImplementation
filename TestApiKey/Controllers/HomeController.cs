using Microsoft.AspNetCore.Mvc;
using TestApiKey.Attributes;

namespace TestApiKey.Controllers;

[ApiController]
[Route("[controller]")]
public class HomeController: ControllerBase
{

    [ApiKeyAuthorize]
    [HttpGet]
    public async Task<IActionResult> GetSecuredUser()
    {
        return Ok();
    }
}