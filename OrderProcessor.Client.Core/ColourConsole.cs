using System;

namespace OrderProcessor.Client.Core
{
    public static class ColorConsole
    {
        private static readonly object LockObject = new object();

        public static void WriteLine(string format, params object[] args)
        {
            WriteLine(string.Format(format, args));
        }

        public static void WriteLine(string text)
        {
            lock (LockObject)
            {
                Console.WriteLine(text);
            }
        }

        public static void WriteLine(ConsoleColor foregroundColor, string format, params object[] args)
        {
            WriteLine(string.Format(format, args), foregroundColor);
        }

        public static void WriteLine(ConsoleColor foregroundColor, string text)
        {
            lock (LockObject)
            {
                var backupColor = Console.ForegroundColor;
                Console.ForegroundColor = foregroundColor;

                Console.WriteLine(text);

                Console.ForegroundColor = backupColor;
            }
        }
    }
}