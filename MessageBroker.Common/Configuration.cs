namespace MessageBroker.Common;

public record Configuration
{
    public string HostName => "localhost";
    public string Topic => "logs";

}