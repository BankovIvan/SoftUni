namespace Telephony.Models.Exceptions
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class InvalidURLException : Exception
    {
        private const string DEFAULT_EXCEPTION_MESSAGE = "Invalid URL!";

        public InvalidURLException() : base(DEFAULT_EXCEPTION_MESSAGE)
        {

        }

        public InvalidURLException(string message) : base(message)
        {

        }
    }
}
