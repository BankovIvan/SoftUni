namespace ListyIterator
{
    using System;
    using System.Collections.Generic;
    //using System.Diagnostics.CodeAnalysis;
    using System.Text;

    public class StrangeCompare : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            int ret = -1;
            bool xEven = (x & 1) == 1;
            bool yEven = (y & 1) == 1;

            if (xEven && yEven)
            {
                ret = x.CompareTo(y);
            }
            else if (xEven && !yEven)
            {
                ret = 1;
            }
            else if (!xEven && yEven)
            {
                ret = -1;
            }
            else
            {
                ret = x.CompareTo(y); ;
            }

            return ret;
        }
    }
}
