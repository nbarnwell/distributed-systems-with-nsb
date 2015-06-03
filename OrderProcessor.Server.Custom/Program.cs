using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Messaging;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Transactions;
using OrderProcessor.Client.Core;
using OrderProcessor.Messages;
using OrderProcessor.Messages.V1;

namespace OrderProcessor.Server.Custom
{
    class Program
    {
        static void Main(string[] args)
        {
            var assemblyName = Assembly.GetExecutingAssembly().GetName().Name;
            var inputQueueName = MessageQueuePath.Resolve(assemblyName);

            if (!MessageQueue.Exists(inputQueueName))
            {
                ColorConsole.WriteLine(ConsoleColor.Yellow, "Creating input queue {0}...", inputQueueName);
                MessageQueue.Create(inputQueueName, false);
            }

            var inputQueue = new MessageQueue(inputQueueName);
            inputQueue.Formatter = new XmlMessageFormatter(typeof(OrderPlaced).Assembly.GetTypes());

            var enumerator = inputQueue.GetMessageEnumerator2();

            while (true)
            {
                Console.WriteLine("Checking {0} for messages...", inputQueueName);
                while (enumerator.MoveNext() && enumerator.Current != null)
                {
                    var current = enumerator.Current;

                    //using (var transaction = new TransactionScope())
                    //using(var qTx = new MessageQueueTransaction())
                    //{
                    //    qTx.Begin();

                        var msg = current.Body;
                        ColorConsole.WriteLine(ConsoleColor.Green, msg.ToString());

                        // Deserialise
                        // Find handlers for the message type
                        // Invoke the handler(s)
                        // Handle failure

                        enumerator.RemoveCurrent();

                    //    qTx.Commit();
                    //    transaction.Complete();
                    //}
                }
                
                Thread.Sleep(1000);
            }
        }
    }
}
