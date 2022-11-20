namespace Logger.Core.Exceptions
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    internal class EmptyDateTimeException : Exception
    {
        private const string DEFAULT_MESSAGE = "DateTime cannot be empty or white space!";

        public EmptyDateTimeException(string message) : base(message)
        {

        }

        public EmptyDateTimeException() : base(DEFAULT_MESSAGE)
        {

        }
    }
}
