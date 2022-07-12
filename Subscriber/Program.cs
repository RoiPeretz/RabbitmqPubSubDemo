using MessageBroker.Common;
using MessageBroker.Common.RmqSubscriber;

var configuration = new Configuration();
var action = new Action<string>(Console.WriteLine);
var subscriber = new Subscriber();

subscriber.Subscribe(configuration.Topic, action);
Console.WriteLine(" Press [enter] to exit.");
Console.ReadLine();