using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NServiceBus;
using OrderProcessor.Client.Core;
using OrderProcessor.Messages;
using OrderProcessor.Messages.V1;

namespace OrderProcessor.Client.NSB
{
    class Program
    {
        static void Main(string[] args)
        {
            var configuration = new BusConfiguration();
            var conventions = configuration.Conventions();
            conventions.DefiningMessagesAs(type => type.Assembly == typeof(OrderPlaced).Assembly);
            var bus = Bus.CreateSendOnly(configuration);

            ColorConsole.WriteLine("Enter customer reference and press ENTER:");

            string input;
            while (!string.IsNullOrWhiteSpace(input = Console.ReadLine()))
            {
                ColorConsole.WriteLine("Sending message...");
                bus.Send(
                    new OrderPlaced
                    {
                        OrderId = Guid.NewGuid(),
                        CustomerReference = input
                    });
            }
        }
    }
}
