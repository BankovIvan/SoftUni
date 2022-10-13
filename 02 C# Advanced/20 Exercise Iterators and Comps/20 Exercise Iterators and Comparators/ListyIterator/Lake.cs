namespace ListyIterator
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;

    public class Lake<T> : IEnumerable<T>
    {
        public List<T> Frogs { get; set; }

        public Lake(params T[] items)
        {
            this.Frogs = new List<T>(items);
        }

        public IEnumerator<T> GetEnumerator()
        {
            int i = 0;

            for (i = 0; i < Frogs.Count; i += 2)
            {
                yield return Frogs[i];

            }

            i = Frogs.Count - 1;
            if((i & 1) == 0)
            {
                i--;
            }

            for ( ; i >=0; i -= 2)
            {
                yield return Frogs[i];

            }

        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
