using System.Text;
using RabbitMQ.Client;

//Get Configuration 

//Create Connection
var factory = new ConnectionFactory() { HostName = "localhost" };
using (var connection = factory.CreateConnection())

//Create Channel
using (var channel = connection.CreateModel())
{
    channel.ExchangeDeclare(exchange: "logs", type: ExchangeType.Fanout);

    //Publish 
    var message = GetMessage(args);
    
    //Message Builder
    var body = Encoding.UTF8.GetBytes(message);
    Thread.Sleep(300);
    channel.BasicPublish(exchange: "logs",
        routingKey: "",
        basicProperties: null,
        body: body);
    Console.WriteLine(" [x] Sent {0}", message);
}

Console.WriteLine(" Press [enter] to exit.");
Console.ReadLine();

static string GetMessage(string[] args)
{
    return ((args.Length > 0)
        ? string.Join(" ", args)
        : "info: Hello World!");
}