using Application.Features.Roles.RoleSync;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class RolesController : CustomBaseController
{
    [HttpGet]
    public async Task<IActionResult> Sync()
    {

        var response=await Mediator.Send(new RoleSyncCommand());    
        return Ok(response);
    }
}
