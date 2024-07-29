using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class EmailController : ControllerBase
{
    private readonly IEmailService _emailService;

    public EmailController(IEmailService emailService)
    {
        _emailService = emailService;
    }
    [HttpPost]
    public async Task<IActionResult> SendEmail (EmailMessage emailMessage)
    {
        await _emailService.SendEmailAsync(emailMessage);
        return Ok();
    }
}
