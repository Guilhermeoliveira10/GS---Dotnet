using System.Text;
using System.Text.Json;
using RabbitMQ.Client;

namespace SafeZone.Application.Messaging;

public class RabbitMqProducer
{
    private readonly string _hostname = "localhost";
    private readonly string _queueName = "helprequest-queue";

    public void SendMessage<T>(T message)
    {
        var factory = new ConnectionFactory() { HostName = _hostname };

        using RabbitMQ.Client.IConnection connection = factory.CreateConnection();
        using RabbitMQ.Client.IModel channel = connection.CreateModel();

        channel.QueueDeclare(
            queue: _queueName,
            durable: false,
            exclusive: false,
            autoDelete: false,
            arguments: null
        );

        string json = JsonSerializer.Serialize(message);
        var body = Encoding.UTF8.GetBytes(json);

        channel.BasicPublish(
            exchange: "",
            routingKey: _queueName,
            basicProperties: null,
            body: body
        );

        Console.WriteLine($"✅ Mensagem enviada para o RabbitMQ: {json}");
    }
}
