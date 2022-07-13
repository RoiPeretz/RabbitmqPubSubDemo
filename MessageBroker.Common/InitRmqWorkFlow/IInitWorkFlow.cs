using RabbitMQ.Client;

namespace MessageBroker.Common.InitRmqWorkFlow;

public interface IInitWorkFlow
{
    IModel Init();
}