namespace Logger.Core.Formatting
{
    using Logger.Core.Formatting.Interfaces;
    using Logger.Core.Formatting.Layouts.Interfaces;
    using Logger.Core.Models.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class MessageFormatter : IFormatter
    {
        public string Format(IMessage message, ILayout layout)
        {
            return string.Format(layout.Format, message.DateTime, message.ReportLevel.ToString(), message.MessageText);
        }
    }
}
