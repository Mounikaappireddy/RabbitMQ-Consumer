using RabbitMQ.Client;
using System;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var factory = new ConnectionFactory
            {
                Uri = new System.Uri("amqp://guest:guest@localhost:5672")
            };
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();
            QueueConsumer.consume(channel);
        }
    }
}
