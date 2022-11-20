namespace Logger.ConsoleApp.Exceptions
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class InvalidAppenderTyptException : Exception
    {
        private const string DEFAULT_MESSAGE = "Invalid Appender type specified!";

        public InvalidAppenderTyptException(string message) : base(message)
        {

        }

        public InvalidAppenderTyptException() : base(DEFAULT_MESSAGE)
        {

        }
    }
}
