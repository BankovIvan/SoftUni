namespace _04_Generic_Swap_Method_Integers
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public static class GenericSwap
    {

        public static void SwapElements<T>(List<T> lstElements, int index1, int index2)
        {
            if(lstElements == null)
            {
                throw new ArgumentNullException("Null list parameter!");
            }

            if(index1 < 0 || index2 < 0 || index1 >= lstElements.Count || index2 >= lstElements.Count)
            {
                throw new ArgumentOutOfRangeException("Index out of range!");
            }

            T temp = lstElements[index1];
            lstElements[index1] = lstElements[index2];
            lstElements[index2] = temp;

        }

    }
}
