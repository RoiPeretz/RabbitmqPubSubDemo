using RabbitMQ.Client;

namespace MessageBroker.Common.InitRmqWorkFlow.CreateRmqConnectionTask;

internal class CreateConnectionTask : ICreateConnectionTask
{
    private readonly ConnectionFactory _factory;

    public CreateConnectionTask(Configuration configuration)
    {
        _factory = new ConnectionFactory() { HostName = configuration.HostName };
    }

    public IConnection CreateConnection()
    {
        return _factory.CreateConnection();
    }
}