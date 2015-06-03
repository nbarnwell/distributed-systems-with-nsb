using System;
using System.Collections;
using System.Messaging;
using System.Threading;
using OrderProcessor.Client.Core;
using OrderProcessor.Messages;
using OrderProcessor.Messages.V1;

namespace OrderProcessor.Client.Custom
{
    class Program
    {
        static void Main(string[] args)
        {
            var targetQueuePath = MessageQueuePath.Resolve("OrderProcessor.Server.Custom");

            while (!MessageQueue.Exists(targetQueuePath))
            {
                ColorConsole.WriteLine(ConsoleColor.Yellow, "Waiting for target queue {0} to be created...", targetQueuePath);
                Thread.Sleep(500);
            }

            var targetQueue = new MessageQueue(targetQueuePath);
            targetQueue.Formatter = new XmlMessageFormatter(typeof(OrderPlaced).Assembly.GetTypes());

            ColorConsole.WriteLine("Enter customer reference and press ENTER:");

            string input;
            while (!string.IsNullOrWhiteSpace(input = Console.ReadLine()))
            {
                ColorConsole.WriteLine("Sending message to {0}...", targetQueuePath);
                targetQueue.Send(
                    new OrderPlaced
                    {
                        OrderId = Guid.NewGuid(),
                        CustomerReference = input
                    });
            }
        }
    }
}
