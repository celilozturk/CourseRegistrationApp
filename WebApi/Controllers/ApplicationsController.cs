using Application.Features.Applications.Commands.Create;
using Application.Features.Applications.Queries.GetCountByCourseId;
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
        var response = await Mediator.Send(createApplicationCommand);
        return Ok(response);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetApplicationCountByCourseId(int id)
    {   GetCountByCourseIdApplicationQuery query= new GetCountByCourseIdApplicationQuery() { courseId=id};
        var response = await Mediator.Send(query);
        return Ok(response);
    }
}
