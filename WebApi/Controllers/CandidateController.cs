using Application.Features.Candidates.Commands;
using Application.Features.Candidates.Queries.GetById;
using Application.Features.Candidates.Queries.GetList;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CandidateController : CustomBaseController
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var response =await Mediator.Send(new GetListCandidateQuery());
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var query= new GetByIdCandidateQuery() { Id=id};
        var response = await Mediator.Send(query);
        return Ok(response);
    }
    [HttpPost]
    public async Task<IActionResult> Create(CreateCandidateCommand createCandidateCommand)
    {
        var response = await Mediator.Send(createCandidateCommand);
        return Ok(response);
    }
}
