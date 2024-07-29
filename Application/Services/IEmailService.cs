using Domain.Entities;

namespace Application.Services;
public interface IEmailService
{
    //void SendEmail(EmailMessage  emailMessage);
    Task SendEmailAsync(EmailMessage emailMessage);
}
