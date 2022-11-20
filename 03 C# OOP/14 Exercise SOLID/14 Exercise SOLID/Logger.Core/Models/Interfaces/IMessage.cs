namespace Logger.Core.Models.Interfaces
{
    using Logger.Core.Enums;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IMessage
    {
        public string MessageText { get; }
        public string DateTime { get; }
        public ReportLevel ReportLevel { get; }

    }
}
