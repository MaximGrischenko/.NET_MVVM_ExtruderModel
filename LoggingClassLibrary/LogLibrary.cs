using System;
using NLog;

namespace LoggingClassLibrary
{
    public class LogLibrary : ILogLibrary
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public void Message(string message)
        {
            Logger.Info(message);
        }

        public void Alarm(string message)
        {
            Logger.Error(message);
        }

        public void Error(Exception e, string message)
        {
            var innerException = e != null && e.InnerException != null ? e.InnerException.Message : "";
            Logger.Fatal("Ошибка :  {0}. Описание {1}", message, e != null ? e.Message + innerException : " отсутствует ");
        }
    }
}
