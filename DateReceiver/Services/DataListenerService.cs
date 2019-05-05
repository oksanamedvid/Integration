using System;
using System.Linq;
using System.Text;
using DateReceiver;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace DataReceiver.Services
{
    public class DataListenerService
    {
        public void Register()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "hello",
                    durable: false,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null);

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body;
                    var job = JsonConvert.DeserializeObject<JobVacancy>(Encoding.UTF8.GetString(body));

                    using (var context = new JobContext())
                    {
                        if (!context.JobVacancies.Any(j => j.Title.Equals(job.Title, StringComparison.InvariantCultureIgnoreCase)))
                        {
                            context.JobVacancies.Add(job);
                            context.SaveChanges();
                        }
                    }

                    Console.WriteLine(job.Title);
                };
                channel.BasicConsume(queue: "hello",
                    autoAck: true,
                    consumer: consumer);

                Console.ReadLine();
            }
        }
    }
}
