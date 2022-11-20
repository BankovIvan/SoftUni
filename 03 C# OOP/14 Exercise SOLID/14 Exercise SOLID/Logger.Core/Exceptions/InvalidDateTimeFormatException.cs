namespace Logger.Core.Exceptions
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    internal class InvalidDateTimeFormatException : Exception
    {
        private const string DEFAULT_MESSAGE = "Provided DateTime format not supported! Try adding the format using DateTimeValidator.RegisterNewFormat() method.!";

        public InvalidDateTimeFormatException(string message) : base(message)
        {

        }

        public InvalidDateTimeFormatException() : base(DEFAULT_MESSAGE)
        {

        }
    }
}
