namespace _06_Generic_Count_Method_Doubles
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public static class GenericCount
    {
        public static int Compare<T>(List<T> lstData, T element) where T:IComparable<T>
        {
            int ret = 0;

            foreach(var v in lstData)
            {
                if(v.CompareTo(element) > 0)
                {
                    ret++;
                }
            }

            return ret;

        }


    }
}
