namespace Logger.Core.Exceptions
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class EmptyMessageTextException : Exception
    {
        private const string DEFAULT_MESSAGE = "Message text cannot be null or whitespace!";

        public EmptyMessageTextException(string message) : base(message)
        {

        }

        public EmptyMessageTextException() : base(DEFAULT_MESSAGE)
        {

        }

    }
}
