using Microsoft.AspNetCore.Mvc;

namespace CrudTest.Api.Controllers;

[ApiController]
public class ErrorsController : ControllerBase
{
    [Route("/error")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public IActionResult Error()
    {
        return Problem();
    }
}
