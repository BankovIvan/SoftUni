namespace Logger.Core.Exceptions
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    internal class InvalidPathException : Exception
    {
        private const string DEFAULT_MESSAGE = "Provided path does not exists or is invalid!";

        public InvalidPathException(string message) : base(message)
        {

        }

        public InvalidPathException() : base(DEFAULT_MESSAGE)
        {

        }
    }
}
