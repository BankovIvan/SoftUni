namespace CustomStack
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class StackOfStrings : Stack<string>
    {
        public bool IsEmpty() 
        { 
            bool ret = this == null;

            if (!ret)
            {
                ret = this.Count == 0;
            }

            return ret;

        }

        public void AddRange(IEnumerable<string> collection)
        {
            foreach(var v in collection)
            {
                this.Push(v);
            }

        } 

    }
}
