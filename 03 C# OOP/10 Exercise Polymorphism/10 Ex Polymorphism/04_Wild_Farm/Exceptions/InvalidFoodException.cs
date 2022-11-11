namespace WildFarm.Exceptions
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class InvalidFoodException : Exception
    {
        private const string DEFAULT_MESSAGE = "Invalid food type!";

        public InvalidFoodException() : base(DEFAULT_MESSAGE)
        {

        }

        public InvalidFoodException(string message) : base(message)
        {

        }
    }
}
