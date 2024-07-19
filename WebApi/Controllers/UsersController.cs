using Application.Features.Users.Commands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UsersController : CustomBaseController
{
    [HttpPost]
    public async Task<IActionResult> Create(CreateUserCommand createUserCommand,CancellationToken cancellationToken)
    {
        var result= Mediator.Send(createUserCommand, cancellationToken);
        return Ok(result);  
    }
}
