namespace CustomRandomList
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class RandomList : List<string>
    {
        private Random rnd;

        public RandomList()
        {
            this.rnd = new Random();
        }

        public string RandomString()
        {
            string ret = null;

            int index = rnd.Next(0, this.Count);

            ret = this[index];

            this.RemoveAt(index);

            return ret;
        }
    }
}
