using System;
using System.Text;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace DataRetriverDLL
{
    public class DataSender
    {
        public static void SendData(JobVacancy job)
        {
            var factory = new ConnectionFactory() {HostName = "localhost"};
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "hello",
                    durable: false,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null);

                var properties = channel.CreateBasicProperties();
                properties.Persistent = true;
                Console.WriteLine(job.CompanyName);

                var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(job));

                channel.BasicPublish(exchange: "",
                    routingKey: "hello",
                    basicProperties: properties,
                    body: body);
            }
        }
    }
}
