using Application.Features.Courses.Commands.Create;
using Application.Features.Courses.Queries.GetList;
using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CoursesController : CustomBaseController
{
    [HttpPost]
    public async Task<IActionResult> Create(CreateCourseCommand createCourseCommand)
    {
        var response= await Mediator.Send(createCourseCommand);
        return Ok(response);    
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var response= await Mediator.Send(new GetListCourseQuery());
        return Ok(response);
    }
}
