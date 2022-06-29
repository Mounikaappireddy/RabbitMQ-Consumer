using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
   public static  class QueueConsumer
    {
        public static void consume(IModel channel)
        {
            channel.QueueDeclare("batch22.queuel",
             durable:true,
               exclusive: false,
               autoDelete: false,
               arguments: null);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (sender, e) =>
             {
                 var body = e.Body.ToArray();
                 var message = Encoding.UTF8.GetString(body);
                 Console.WriteLine(message);
             };
            channel.BasicConsume("batch22.queuel", true, consumer);
            Console.WriteLine("Consumer Started");
            Console.ReadLine();
        }
    }
}
