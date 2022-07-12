using MessageBroker.Common;
using MessageBroker.Common.RmqPublisher;

var configuration = new Configuration();

var publisher = new Publisher();
publisher.Publish(configuration.Topic,"Hello World!");

Console.WriteLine(" Press [enter] to exit.");
Console.ReadLine();

