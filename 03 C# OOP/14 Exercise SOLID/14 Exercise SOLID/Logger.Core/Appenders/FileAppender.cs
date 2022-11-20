namespace Logger.Core.Appenders
{
    using Logger.Core.Formatting.Layouts.Interfaces;
    using Logger.Core.Formatting;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Logger.Core.Appenders.Interfaces;
    using Logger.Core.Models.Interfaces;
    using Logger.Core.Formatting.Interfaces;
    using Logger.Core.IO.Interfaces;
    using System.IO;
    using Logger.Core.Enums;

    public class FileAppender : IAppender
    {
        private ILayout layout;
        private readonly IFormatter formatter;
        private ILogFile logFile;
        private readonly ReportLevel reportLevel;

        public ILayout Layout { get { return this.layout; } private set { this.layout = value; } }

        public ILogFile LogFile { get { return this.logFile; } private set { this.logFile = value; } }

        public ReportLevel ReportLevel { get { return this.reportLevel; } }

        public FileAppender()
        {
            this.formatter = new MessageFormatter();
        }

        public FileAppender(ILayout layout, ILogFile logFile, ReportLevel reportLevel = 0) : this()
        {
            this.Layout= layout;
            this.LogFile= logFile;  
            this.reportLevel= reportLevel;
        }

        public void AppendMessage(IMessage message)
        {
            string ret = this.formatter.Format(message, this.Layout);
            this.LogFile.WriteLine(ret);
            //File.AppendAllText(this.LogFile.Path, this.LogFile.Content);
            this.LogFile.SaveContent();

        }
    }
}
