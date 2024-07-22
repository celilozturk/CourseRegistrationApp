using Application.Features.Courses.Commands.Create;
using Application.Features.Courses.Commands.Delete;
using Application.Features.Courses.Commands.Update;
using Application.Features.Courses.Queries.GetById;
using Application.Features.Courses.Queries.GetList;
using Application.Features.Courses.Queries.GetListWithEnrollments;
using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[Route("api/[controller]/[action]")]
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

    [HttpGet]
    public async Task<IActionResult> GetAllWithEnrollments()
    {
        var response = await Mediator.Send(new GetListCourseWithEnrollmentsQuery());
        return Ok(response);
    }

    //[ProducesResponseType(typeof(GetByIdCourseResponse),StatusCodes.Status200OK)]
    //[ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var query= new GetByIdCourseQuery() { Id=id};
        var response = await Mediator.Send(query);
        return Ok(response);    
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var response= await Mediator.Send(new DeleteCourseCommand(id));
        return Ok(response);    
    }
    [HttpPut]
    public async Task<IActionResult> Update(UpdateCourseCommand updateCourseCommand)
    {
        var response = await Mediator.Send(updateCourseCommand); 
        return Ok(response);
    }
}
