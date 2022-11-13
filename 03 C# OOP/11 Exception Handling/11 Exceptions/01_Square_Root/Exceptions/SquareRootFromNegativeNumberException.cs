namespace SquareRoot.Exceptions
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class SquareRootFromNegativeNumberException : Exception
    {
        private const string DEFAULT_MESSAGE = ExceptionMessages.SQUARE_ROOT_FROM_NEGATIVE_NUMBER;

        public SquareRootFromNegativeNumberException() : base(DEFAULT_MESSAGE)
        {

        }

        public SquareRootFromNegativeNumberException(string message) : base(message)
        {

        }

    }
}
