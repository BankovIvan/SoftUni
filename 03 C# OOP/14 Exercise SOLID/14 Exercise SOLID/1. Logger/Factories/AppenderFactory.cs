namespace Logger.ConsoleApp.Factories
{
    using Logger.ConsoleApp.Exceptions;
    using Logger.ConsoleApp.Factories.Interfaces;
    using Logger.Core.Appenders;
    using Logger.Core.Appenders.Interfaces;
    using Logger.Core.Enums;
    using Logger.Core.Formatting.Layouts.Interfaces;
    using Logger.Core.IO;
    using Logger.Core.IO.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class AppenderFactory : IAppenderFactory
    {
        public IAppender CreateAppender(string type, ILayout layout, ReportLevel reportLevel = 0, ILogFile logFile = null)
        {
            IAppender ret = null;
            if(type == "ConsoleAppender")
            {
                ret = new ConsoleAppender(layout, reportLevel);
            }
            else if(type == "FileAppender")
            {
                if(logFile == null)
                {
                    logFile = new LogFile("", "../../../Logs", "SOLID.log.txt");
                }
                ret = new FileAppender(layout, logFile, reportLevel);
            }
            else
            {
                throw new InvalidAppenderTyptException();
            }

            return ret;
        }
    }
}
