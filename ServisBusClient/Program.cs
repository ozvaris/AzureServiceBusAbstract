using QueueLib;
using System;

namespace ServisBusClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = GetQueue();
            Console.WriteLine("Write exit to exit");
            string val = "test message";
            service.Send(val);
            Console.WriteLine("test message has sent");

            while (true)
            {
                val = Console.ReadLine();

                if (val == "exit")
                    break;

                service.Send(val);
            }
            

           

        }

        static IQueueService GetQueue()
        {
            // Central logic that returns the queue to use  
            string connectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
            string queueName = System.Configuration.ConfigurationManager.AppSettings["queueName"];

            // Detect which kind of queue we need to create, based on the connection string  
            IQueueService service = null;
            if (connectionString.ToLower().Contains("core.windows.net"))
                service = new AZQueue();
            else if (connectionString.ToLower().Contains("sb://"))
                service = new AZBus();

            service.ConnectionString = connectionString;
            service.QueueName = queueName;

            return service;
        }
    }
}
