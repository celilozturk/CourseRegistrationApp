using Azure.Storage.Queues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.Email.AzureQueueEmailService;
public static class AzureQueueClientFactory
{
    public static QueueClient CreateQueueClient(string connectionString, string queueName)
    {
        var queueClient = new QueueClient(connectionString, queueName);
        queueClient.CreateIfNotExists();
        return queueClient;
    }
}
