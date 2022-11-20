namespace Logger.ConsoleApp.Factories.Interfaces
{
    using Logger.Core.Appenders.Interfaces;
    using Logger.Core.Enums;
    using Logger.Core.Formatting.Layouts.Interfaces;
    using Logger.Core.IO.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IAppenderFactory
    {
        IAppender CreateAppender(string type, ILayout layout, ReportLevel reportLevel, ILogFile logFile);
    }
}
