using System;

namespace OrderProcessor.Client.Core
{
    public static class ColorConsole
    {
        private static readonly object LockObject = new object();

        public static void Write(string format, params object[] args)
        {
            Write(string.Format(format, args));
        }

        public static void Write(string text)
        {
            lock (LockObject)
            {
                Console.Write(text);
            }
        }

        public static void Write(ConsoleColor foregroundColor, string format, params object[] args)
        {
            Write(foregroundColor, string.Format(format, args));
        }

        public static void Write(ConsoleColor foregroundColor, string text)
        {
            WriteInColor(foregroundColor, () => Console.Write(text));
        }

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
            WriteLine(foregroundColor, string.Format(format, args));
        }

        public static void WriteLine(ConsoleColor foregroundColor, string text)
        {
            WriteInColor(foregroundColor, () => Console.WriteLine(text));
        }

        private static void WriteInColor(ConsoleColor foregroundColor, Action writeAction)
        {
            lock (LockObject)
            {
                var backupColor = Console.ForegroundColor;
                Console.ForegroundColor = foregroundColor;

                writeAction();

                Console.ForegroundColor = backupColor;
            }
        }
    }
}