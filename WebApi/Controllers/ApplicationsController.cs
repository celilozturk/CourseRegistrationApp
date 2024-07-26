using Application.Features.Applications.Create;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ApplicationsController : CustomBaseController
{
    [HttpPost]
    public async Task<IActionResult> Apply(CreateApplicationCommand createApplicationCommand)
    {
      var response=  await Mediator.Send(createApplicationCommand);
        return Ok(response);
    }
}
