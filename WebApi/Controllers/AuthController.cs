using Application.Features.Auth.Login;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AuthController : CustomBaseController
{
    [HttpPost]
    public async Task<IActionResult> Login(LoginCommand loginCommand,CancellationToken cancellationToken)
    {
        var response= await Mediator.Send(loginCommand,cancellationToken);
        return Ok(response);
    }
}
