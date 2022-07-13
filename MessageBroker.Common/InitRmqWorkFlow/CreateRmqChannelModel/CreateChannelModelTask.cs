using RabbitMQ.Client;

namespace MessageBroker.Common.InitRmqWorkFlow.CreateRmqChannelModel;

internal class CreateChannelModelTask : ICreateChannelModelTask
{
    public IModel Create(IConnection connection)
    {
       return connection.CreateModel();
    }
}