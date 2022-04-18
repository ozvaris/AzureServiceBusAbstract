using System;
namespace QueueLib
{
    public interface IQueueService
    {
        void Send(string payload);
        string ConnectionString { get; set; }
        string QueueName { get; set; }
    }
}