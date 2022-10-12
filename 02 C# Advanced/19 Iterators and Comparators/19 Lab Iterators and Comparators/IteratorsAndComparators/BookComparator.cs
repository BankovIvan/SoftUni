namespace IteratorsAndComparators
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class BookComparator : IComparer<Book>
    {
        public int Compare(Book x, Book y)
        {
            int ret = 0;

            ret = x.Title.CompareTo(y.Title);

            if (ret == 0)
            {
                ret = y.Year.CompareTo(x.Year);
            }

            if (ret == 0)
            {
                ret = x.Id.CompareTo(y.Id);
            }

            return ret;
        }
    }
}
