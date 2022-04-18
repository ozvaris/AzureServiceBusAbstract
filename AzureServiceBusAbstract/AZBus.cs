using Microsoft.Azure.ServiceBus;
using System.Text;

namespace QueueLib
{
    public class AZBus : IQueueService
    {
        public string ConnectionString { get; set; }
        public string QueueName { get; set; }
        private static IQueueClient queueClient;
        public void Send(string payload)
        {
            queueClient = new QueueClient(ConnectionString, QueueName);
            var message = new Message(Encoding.UTF8.GetBytes(payload));
            queueClient.SendAsync(message).Wait();
        }
    }
}