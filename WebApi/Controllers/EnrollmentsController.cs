﻿using Application.Features.Enrollments.Commands.Approve;
using Application.Features.Enrollments.Commands.Create;
using Application.Features.Enrollments.Commands.Delete;
using Application.Features.Enrollments.Commands.Update;
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
    [HttpPost]
    public async Task<IActionResult> Create(CreateEnrollmentCommand createEnrollmentCommand)
    {       
        var response = await Mediator.Send(createEnrollmentCommand);
        return Ok(response);
    }
    [HttpPut]
    public async Task<IActionResult> Update(UpdateEnrollmentCommand updateEnrollmentCommand)
    {
        var response = await Mediator.Send(updateEnrollmentCommand);
        return Ok(response);
    }
    [HttpDelete]
    public async Task<IActionResult> Delete(DeleteEnrollmentCommand deleteEnrollmentCommand)
    {
        var response = await Mediator.Send(deleteEnrollmentCommand);
        return Ok(response);
    }
    [HttpPost("[action]/{id}")]
    public async Task<IActionResult> Approve([FromRoute]int id)
    { 
        var command= new ApproveEnrollmentCommand() { Id=id };
        var response = await Mediator.Send(command);
        return Ok(response);
    }
}
