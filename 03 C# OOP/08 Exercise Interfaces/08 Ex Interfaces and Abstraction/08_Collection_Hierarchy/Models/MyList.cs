namespace Collection.Models
{
    using Collection.Models.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class MyList : IMyList
    {
        private List<string> items;

        public IReadOnlyCollection<string> Items { get => this.items.AsReadOnly(); }

        public int Used { get => this.items.Count; }

        public MyList()
        {
            this.items = new List<string>();
        }

        public int Add(string item)
        {
            this.items.Insert(0, item);
            return 0;
        }

        public string Remove()
        {
            string ret = null;
            if (this.items.Count > 0)
            {
                ret = this.items[0];
                this.items.RemoveAt(0);
            }

            return ret;
        }
    }
}
