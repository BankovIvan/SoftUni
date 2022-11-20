namespace Logger.ConsoleApp.Exceptions
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class InvalidLayoutTypeException : Exception
    {
        private const string DEFAULT_MESSAGE = "Invalid Layout type specified!";

        public InvalidLayoutTypeException(string message) : base(message)
        {

        }

        public InvalidLayoutTypeException() : base(DEFAULT_MESSAGE)
        {

        }
    }
}
