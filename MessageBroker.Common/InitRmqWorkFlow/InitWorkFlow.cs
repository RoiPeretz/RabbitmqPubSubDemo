using MessageBroker.Common.InitRmqWorkFlow.CreateRmqChannelModel;
using MessageBroker.Common.InitRmqWorkFlow.CreateRmqConnectionTask;
using RabbitMQ.Client;

namespace MessageBroker.Common.InitRmqWorkFlow;

public class InitWorkFlow : IInitWorkFlow
{
    private readonly ICreateConnectionTask _createConnectionTask;
    private readonly ICreateChannelModelTask _createChannelModelTask;

    public InitWorkFlow()
    {
        var configuration = new Configuration();
        _createConnectionTask = new CreateConnectionTask(configuration);
        _createChannelModelTask = new CreateChannelModelTask();
    }

    public IModel Init()
    {
        var connection = _createConnectionTask.CreateConnection();
        var model = _createChannelModelTask.Create(connection);
        return model;
    }
}