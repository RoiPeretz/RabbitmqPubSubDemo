using System.Text;
using MessageBroker.Common.InitRmqWorkFlow;
using MessageBroker.Common.RmqPublisher;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace MessageBroker.Common.RmqSubscriber;

public class Subscriber: IDisposable, ISubscriber
{
    private readonly IModel _channel;
    private readonly EventingBasicConsumer _consumer;

    public Subscriber()
    {
        var initWorkFlow = new InitWorkFlow();
        _channel = initWorkFlow.Init();
        _consumer = new EventingBasicConsumer(_channel);
        _consumer.Received += (model, ea) =>
        {
            // if (ea. == "neria")
            // {
            //
            // }
        };
    }

    public void Subscribe(string topic, Action<string> onMessage)
    {
        // _channel.ExchangeDeclare(exchange: topic, type: ExchangeType.Fanout);

        var queueName = _channel.QueueDeclare().QueueName;

        // _channel.QueueBind(queue: queueName,
        //     exchange: topic,
        //     routingKey: "");

        // consumer = new EventingBasicConsumer(_channel, topic);

        // _consumer.Received += (model, ea) =>
        // {
        //     Console.WriteLine(topic);
        //     var body = ea.Body.ToArray();
        //     var message = Encoding.UTF8.GetString(body);
        //     onMessage.Invoke(message);
        // };
        
        _channel.BasicConsume(queue: queueName,
            autoAck: true,
            consumer: _consumer);
    }

    public void Dispose()
    {
        _channel.Dispose();
    }
}