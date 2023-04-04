using System.Text;
using static System.Console;
using System.Threading.Tasks;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace RabbitMQ_library
{
    public class Consumer
    {
        public static async Task RabbitMQ_ConsumerAsync(string nameQueue, string nameExchange)
        {
            while (true)
            {
                var factory = new ConnectionFactory { HostName = "localhost" };
                var connection = factory.CreateConnection();
                var channel = connection.CreateModel();
                channel.ExchangeDeclare(exchange: nameExchange, type: ExchangeType.Fanout);

                //var queueName = channel.QueueDeclare().QueueName;
                channel.QueueBind(queue: nameQueue, exchange: nameExchange, routingKey: "");

                var consumer = new EventingBasicConsumer(channel);
                var tcs = new TaskCompletionSource<bool>();

                consumer.Received += (model, e) =>
                {
                    var body = e.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    WriteLine($"Received: {message}");
                    tcs.TrySetResult(true);
                };

                channel.BasicConsume(queue: nameQueue, autoAck: true, consumer: consumer);

                while (!tcs.Task.IsCompleted)
                {
                    await Task.Delay(100);
                }
            }
        }
    }
}
