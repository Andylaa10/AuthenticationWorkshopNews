using Microsoft.AspNetCore.Mvc;

namespace NewsAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class NewController : ControllerBase
{
    [HttpGet]
    public IActionResult GetNews()
    {
        return Ok();
    }
}