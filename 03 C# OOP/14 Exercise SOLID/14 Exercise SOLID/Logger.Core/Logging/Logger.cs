namespace Logger.Core.Logging
{
    using global::Logger.Core.Appenders.Interfaces;
    using global::Logger.Core.Enums;
    using global::Logger.Core.Logging.Interfaces;
    using global::Logger.Core.Models;
    using global::Logger.Core.Models.Interfaces;
    //using Logger.Core.Enums;
    //using Logger.Core.Models.Interfaces;
    //using Logger.Core.Appenders.Interfaces;
    //using Logger.Core.Logging.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Logger : ILogger
    {
        private readonly ICollection<IAppender> appenders;

        public Logger(params IAppender[] appenders) 
        { 
            this.appenders = appenders;
        }

        public Logger(ICollection<IAppender> appenders)
        {
            this.appenders = appenders;
        }

        public void Info(string dateTime, string message)
        {
            this.Append(dateTime, message, ReportLevel.Info);
        }

        public void Warning(string dateTime, string message)
        {
            this.Append(dateTime, message, ReportLevel.Warning);
        }

        public void Error(string dateTime, string message)
        {
            this.Append(dateTime, message, ReportLevel.Error);
        }

        public void Critical(string dateTime, string message)
        {
            this.Append(dateTime, message, ReportLevel.Critical);
        }

        public void Fatal(string dateTime, string message)
        {
            this.Append(dateTime, message, ReportLevel.Fatal);
        }

        private void Append(string dateTime, string messageText, ReportLevel reportLevel)
        {
            IMessage message = new Message(messageText, dateTime, reportLevel);
            foreach(var appender in appenders)
            {
                if(message.ReportLevel >= appender.ReportLevel)
                {
                    appender.AppendMessage(message);
                }
            }
        }

    }
}
