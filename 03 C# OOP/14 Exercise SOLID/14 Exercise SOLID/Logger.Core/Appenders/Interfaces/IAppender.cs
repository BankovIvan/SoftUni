namespace Logger.Core.Appenders.Interfaces
{
    using Logger.Core.Enums;
    using Logger.Core.Formatting.Layouts.Interfaces;
    using Logger.Core.Models.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IAppender
    {
        ILayout Layout { get; }
        ReportLevel ReportLevel { get; }

        void AppendMessage(IMessage message);
    }
}
