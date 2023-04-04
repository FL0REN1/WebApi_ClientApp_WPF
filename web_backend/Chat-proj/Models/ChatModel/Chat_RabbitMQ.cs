using RabbitMQ.Client;
using System.Text;

namespace Chat_proj.Models.ChatModel
{
    public sealed class Chat_RabbitMQ
    {
        private static readonly Lazy<Chat_RabbitMQ> _chatErrorMQ = new (() => new ("Chat_Error_Exchange"));
        private static readonly Lazy<Chat_RabbitMQ> _chatActionMQ = new (() => new ("Chat_Action_Exchange"));

        private readonly string _hostname;
        private readonly string _exchangeName;
        private readonly IModel _channel;

        private Chat_RabbitMQ(string exchangeName)
        {
            _hostname = "localhost";
            _exchangeName = exchangeName;

            var factory = new ConnectionFactory() { HostName = _hostname };
            var connection = factory.CreateConnection();
            _channel = connection.CreateModel();
            _channel.ExchangeDeclare(_exchangeName, ExchangeType.Fanout);
        }

        public static Chat_RabbitMQ ChatErrorMQ => _chatErrorMQ.Value;
        public static Chat_RabbitMQ ChatActionMQ => _chatActionMQ.Value;

        public void SendMessage(string message)
        {
            var body = Encoding.UTF8.GetBytes(message);
            _channel.BasicPublish(_exchangeName, "", null, body);
        }
    }
}
