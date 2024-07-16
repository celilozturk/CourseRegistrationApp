using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

public class CustomBaseController : ControllerBase
{
    private IMediator mediator;
    protected IMediator? Mediator => mediator ??= HttpContext.RequestServices.GetService<IMediator>();
}
