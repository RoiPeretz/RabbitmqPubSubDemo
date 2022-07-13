using RabbitMQ.Client;

namespace MessageBroker.Common.InitRmqWorkFlow.CreateRmqChannelModel;

internal interface ICreateChannelModelTask
{
    IModel Create(IConnection connection);
}