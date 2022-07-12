namespace MessageBroker.Core;

public interface IPublisher
{
    void Publish(string topic, string message);
}