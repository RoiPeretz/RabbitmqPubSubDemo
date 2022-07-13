using System.Text;
using MessageBroker.Common.InitRmqWorkFlow;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace MessageBroker.Common.RmqSubscriber;

public class Subscriber: IDisposable, ISubscriber
{
    private readonly IModel _channel;

    public Subscriber()
    {
        var initWorkFlow = new InitWorkFlow();
        _channel = initWorkFlow.Init();
    }

    public void Subscribe(string topic, Action<string> onMessage)
    {
        try
        {
            _channel.ExchangeDeclare(exchange: topic, type: ExchangeType.Fanout);

            _channel.QueueDeclare(queue: topic,
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null);

            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += (_, ea) =>
            {
                Console.WriteLine(topic);
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                onMessage.Invoke(message);
            };

            _channel.BasicConsume(queue: topic,
                autoAck: true,
                consumer: consumer);
        }
        catch (Exception ex)
        {
            //TODO set result when we add return type
        }
    }

    public void Dispose()
    {
        _channel.Dispose();
    }
}