namespace Logger.Core.Models
{
    using Logger.Core.Enums;
    using Logger.Core.Exceptions;
    using Logger.Core.Models.Interfaces;
    using Logger.Core.Utilities;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Message : IMessage
    {
        private string messageText;
        private string dateTime;
        private ReportLevel reportLevel;

        public string MessageText 
        { 
            get { return this.messageText; } 
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new EmptyMessageTextException();
                }
                this.messageText = value; 
            } 
        }

        public string DateTime 
        { 
            get { return this.dateTime; } 
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new EmptyDateTimeException();
                }

                if (!DateTimeValidator.IsDateTimeValid(value))
                {
                    throw new InvalidDateTimeFormatException();
                }

                this.dateTime = value; 
            } 
        }

        public ReportLevel ReportLevel 
        { 
            get { return this.reportLevel; } 
            private set { this.reportLevel = value; } 
        }

        public Message(string messageText, string dateTime, ReportLevel reportLevel)
        {
            this.MessageText = messageText;
            this.DateTime = dateTime;
            this.ReportLevel = reportLevel;
        }

    }
}
