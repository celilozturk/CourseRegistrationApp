using Application.Services;
using Azure.Storage.Queues;
using Domain.Entities;
using System.Text;
using System.Text.Json;

namespace Infrastructure.Services.Email.AzureQueueStorageEmailFunctionAppService;
public class QueueEmailService : IEmailService
{
    private readonly QueueClient _queueClient;

    public QueueEmailService(QueueClient queueClient)
    {
        _queueClient = queueClient;
    }

    //public void SendEmail(EmailMessage emailMessage)
    //{
    //    throw new NotImplementedException();
    //}

    public async Task SendEmailAsync(EmailMessage emailMessage)
    {
        var message = JsonSerializer.Serialize(emailMessage);
        await _queueClient.SendMessageAsync(Convert.ToBase64String(Encoding.UTF8.GetBytes(message)));
    }
}
