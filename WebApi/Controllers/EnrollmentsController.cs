using Application.Features.Enrollments.Queries.GetById;
using Application.Features.Enrollments.Queries.GetList;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class EnrollmentsController : CustomBaseController
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var response=await Mediator.Send(new GetListEnrollmentQuery());
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {   var query= new GetByIdEnrollmentQuery() { Id=id};
        var response = await Mediator.Send(query);
        return Ok(response);
    }

}
