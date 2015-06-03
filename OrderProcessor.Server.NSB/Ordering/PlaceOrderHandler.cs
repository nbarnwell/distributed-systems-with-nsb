using System;
using NServiceBus;
using OrderProcessor.Client.Core;
using OrderProcessor.Messages;
using OrderProcessor.Messages.V1;

namespace OrderProcessor.Server.NSB.Ordering
{
    public class PlaceOrderHandler : IHandleMessages<OrderPlaced>
    {
        public void Handle(OrderPlaced message)
        {
            ColorConsole.WriteLine(ConsoleColor.Green, "Handling message: {0}", message.ToString());
        }
    }
}