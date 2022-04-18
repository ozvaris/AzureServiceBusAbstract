using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;

namespace QueueLib
{
    public class AZQueue : IQueueService
    {
        public string ConnectionString { get; set; }
        public string QueueName { get; set; }

        public void Send(string payload)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(ConnectionString);
            CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();
            CloudQueue queue = queueClient.GetQueueReference(QueueName);
            CloudQueueMessage message = new CloudQueueMessage(payload);
            queue.AddMessageAsync(message);

        }
    }
}