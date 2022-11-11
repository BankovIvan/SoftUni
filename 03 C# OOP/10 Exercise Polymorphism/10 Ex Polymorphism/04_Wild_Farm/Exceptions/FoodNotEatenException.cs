namespace WildFarm.Exceptions
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class FoodNotEatenException : Exception
    {
        public FoodNotEatenException(string message) : base(message)
        {

        }
    }
}
