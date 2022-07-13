namespace MessageBroker.Common.RmqSubscriber;

public interface ISubscriber
{
    void Subscribe(string topic, Action<string> onMessage);
}