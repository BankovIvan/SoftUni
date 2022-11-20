namespace Logger.Core.Exceptions
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class EmptyFileNameException : Exception
    {
        private const string DEFAULT_MESSAGE = "File name cannot be empty or white space!";

        public EmptyFileNameException(string message) : base(message)
        {

        }

        public EmptyFileNameException() : base(DEFAULT_MESSAGE)
        {

        }
    }
}
