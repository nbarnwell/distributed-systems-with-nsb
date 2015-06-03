namespace OrderProcessor.Client.Core
{
    public static class MessageQueuePath
    {
        public static string Resolve(string machineName, string queueName)
        {
            return string.Format(@"FormatName:DIRECT=OS:{0}\private$\{1}", machineName, queueName);
        }

        public static string Resolve(string queueName)
        {
            return string.Format(@".\private$\{0}", queueName);
        }
    }
}