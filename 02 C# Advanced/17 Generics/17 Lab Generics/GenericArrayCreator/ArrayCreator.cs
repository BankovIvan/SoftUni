namespace GenericArrayCreator
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public static class ArrayCreator
    {
        public static T[] Create<T>(int length, T item)
        {
            T[] ret = new T[length];
            for(int i = 0; i < length; i++)
            {
                ret[i] = item;
            }

            return ret;
        }

    }
}
