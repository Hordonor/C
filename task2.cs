using System;
using System.IO;

namespace Modularr1
{
    class MessagePublisher
    {
        public event Action<string> OnMessageSent;

        public void Send(string message)
        {
            OnMessageSent?.Invoke(message);
        }
    }

    class FileLogger
    {
        public string filename;

        public FileLogger(string name, MessagePublisher publisher)
        {
            filename = name;
            publisher.OnMessageSent += LogMessage;
        }

        public void LogMessage(string message)
        {
            string time = DateTime.Now.ToString();
            string logText = "[" + time + "] " + message + "\n";
            File.AppendAllText(filename, logText);
        }
    }

    public static class task2
    {
        public static void Run()
        {
            string logfile = "messagesPD25.txt";
            if (File.Exists(logfile)) File.Delete(logfile);

            var publisher = new MessagePublisher();
            var logger = new FileLogger(logfile, publisher);

            publisher.Send("Перше повідомлення");
            publisher.Send("Друге повідомлення");
            publisher.Send("Третє повідомлення");

            Console.WriteLine("Повідомлення записані у файл: " + logfile);
        }
    }
}
