using Category.API.Core.Models.Request;
using RabbitMQ.Client;
using System.Text.Json;
using System.Text;

namespace Category.API.Core.EventBus
{
    public class EventBusMessage : IEventBusMessage
    {
        private readonly ConnectionFactory _factory;
        private IConnection _connection;
        private IModel _channel;

        public EventBusMessage()
        {
            _factory = new ConnectionFactory
            {
                HostName = "localhost",
                Port = 5672,
            };

            CreateEventBusConnection();
        }

        public void PublishNewCategory(CategoryRequestModel requestModel)
        {
            var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(requestModel));

            if (_connection.IsOpen)
            {
                _channel.BasicPublish("direct", "new-category", null, body);
            }
        }

        private void CreateEventBusConnection()
        {
            try
            {
                _connection = _factory.CreateConnection();
                _channel = _connection.CreateModel();

                _channel.ExchangeDeclare("direct", type: ExchangeType.Direct);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
