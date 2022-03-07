using Azure.Messaging.ServiceBus;


Console.WriteLine($"Starting");


var serviceBusConnectionString = Environment.GetEnvironmentVariable("ServiceBusConnectionString");
var queuename = Environment.GetEnvironmentVariable("QueueName");

var _serviceBusClient = new ServiceBusClient(serviceBusConnectionString);
var _messageReceiver = _serviceBusClient.CreateReceiver(queuename);


Console.WriteLine($"Waiting for message on queue {queuename}");

var message = await _messageReceiver.ReceiveMessageAsync();


if (message != null)
{
    Console.WriteLine("Got message.");

    Console.WriteLine($"Contents: {message.Body}");
    await _messageReceiver.CompleteMessageAsync(message);
    Console.WriteLine("Message completed.");
}
else
{
    Console.WriteLine("No message received.");
}


Console.WriteLine("Done.");
