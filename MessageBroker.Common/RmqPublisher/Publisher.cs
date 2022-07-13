using System.Text;
using MessageBroker.Common.InitRmqWorkFlow;
using RabbitMQ.Client;

namespace MessageBroker.Common.RmqPublisher;

public class Publisher: IDisposable, IPublisher
{
    private readonly IModel _channel;

    public Publisher()
    {
        var initWorkFlow = new InitWorkFlow();
        _channel = initWorkFlow.Init();
    }

    public void Publish(string topic, string message)
    {
        try
        {
            _channel.ExchangeDeclare(exchange: topic, type: ExchangeType.Fanout);

            _channel.QueueDeclare(queue: topic,
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null);

            var messageInBytes = Encoding.UTF8.GetBytes(message);
            Thread.Sleep(300);
            _channel.BasicPublish(exchange: "",
                routingKey: topic,
                basicProperties: null,
                body: messageInBytes);
            Console.WriteLine(" [x] Sent {0}", message);
        }
        catch (Exception ex)
        {
            //TODO - set result when we add return type
        }
    }

    public void Dispose()
    {
        _channel.Dispose();
    }
}