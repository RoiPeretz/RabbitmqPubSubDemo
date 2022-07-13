using RabbitMQ.Client;

namespace MessageBroker.Common.InitRmqWorkFlow.CreateRmqConnectionTask;

internal interface ICreateConnectionTask
{
    IConnection CreateConnection();
}