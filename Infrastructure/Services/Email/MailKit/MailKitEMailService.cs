using Application.Services;
using Domain.Entities;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;

namespace Infrastructure.Services.Email.MailKit;
public class MailKitEMailService : IEmailService
{
    private readonly EmailSettings _emailSettings;

    public MailKitEMailService(IOptions<EmailSettings> emailSettings)
    {
        _emailSettings = emailSettings.Value;
    }

    //public void SendEmail(EmailMessage emailMessage)
    //{

    //    MimeMessage email = new();
    //    email.From.Add(new MailboxAddress(_emailSettings.SenderFullName, _emailSettings.SenderEmail));

    //    email.To.Add(new MailboxAddress(emailMessage.ToFullName, emailMessage.ToEmail));

    //    email.Subject = emailMessage.Subject;

    //    BodyBuilder bodyBuilder = new()
    //    {
    //        TextBody = emailMessage.TextBody,
    //        HtmlBody = emailMessage.HtmlBody
    //    };
    //    if (emailMessage.Attachments != null)
    //        foreach (MimeEntity? attachment in emailMessage.Attachments)
    //        {
    //            bodyBuilder.Attachments.Add(attachment);
    //        }

    //    email.Body = bodyBuilder.ToMessageBody();

    //    using SmtpClient smtp = new();
    //    smtp.Connect(_emailSettings.Server, _emailSettings.Port);
    //    //smtp.Authenticate(_mailSettings.UserName, _mailSettings.Password);
    //    smtp.Send(email);
    //    smtp.Disconnect(true);
    //}

    public async Task SendEmailAsync(EmailMessage emailMessage)
    {
        MimeMessage email = new();
        email.From.Add(new MailboxAddress(_emailSettings.SenderFullName, _emailSettings.SenderEmail));

        email.To.Add(new MailboxAddress(emailMessage.ToFullName, emailMessage.ToEmail));

        email.Subject = emailMessage.Subject;

        BodyBuilder bodyBuilder = new()
        {
            TextBody = emailMessage.TextBody,
            HtmlBody = emailMessage.HtmlBody
        };
        if (emailMessage.Attachments != null)
            foreach (MimeEntity? attachment in emailMessage.Attachments)
            {
                bodyBuilder.Attachments.Add(attachment);
            }

        email.Body = bodyBuilder.ToMessageBody();

        using SmtpClient smtp = new();
        smtp.ConnectAsync(_emailSettings.Server, _emailSettings.Port);
        //smtp.AuthenticateAsync(_mailSettings.UserName, _mailSettings.Password);
        smtp.SendAsync(email);
        smtp.DisconnectAsync(true);
    }
}
