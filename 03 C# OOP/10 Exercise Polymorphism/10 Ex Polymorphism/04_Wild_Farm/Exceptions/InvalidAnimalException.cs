namespace WildFarm.Exceptions
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class InvalidAnimalException : Exception
    {
        private const string DEFAULT_MESSAGE = "Invalid animal type!";

        public InvalidAnimalException() : base(DEFAULT_MESSAGE)
        {

        }

        public InvalidAnimalException(string message) : base(message)
        {

        }

    }
}
