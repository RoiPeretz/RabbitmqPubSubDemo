namespace MessageBroker.Common.RmqPublisher;

internal interface IPublisher
{
    void Publish(string topic, string message);
}