namespace Logger.Core.Appenders
{
    using Logger.Core.Appenders.Interfaces;
    using Logger.Core.Enums;
    using Logger.Core.Formatting;
    using Logger.Core.Formatting.Interfaces;
    using Logger.Core.Formatting.Layouts.Interfaces;
    using Logger.Core.Models.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ConsoleAppender : IAppender
    {
        private ILayout layout;
        private readonly IFormatter formatter;
        private ReportLevel reportLevel;

        public ILayout Layout { get { return this.layout; } private set { this.layout = value; } }

        public IFormatter Formatter { get { return this.formatter; } }

        public ReportLevel ReportLevel { get { return this.reportLevel; } set { this.reportLevel = value; } }

        public ConsoleAppender()
        {
            this.formatter = new MessageFormatter();
        }

        public ConsoleAppender(ILayout layout, ReportLevel reportLevel = 0) : this()
        {
            this.Layout = layout;
            this.reportLevel = reportLevel;
        }

        public void AppendMessage(IMessage message)
        {
            string ret = this.formatter.Format(message, this.Layout);
            Console.WriteLine(ret);
        }
    }
}
