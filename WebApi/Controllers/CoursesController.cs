using Application.Features.Courses.Commands.Create;
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
}
