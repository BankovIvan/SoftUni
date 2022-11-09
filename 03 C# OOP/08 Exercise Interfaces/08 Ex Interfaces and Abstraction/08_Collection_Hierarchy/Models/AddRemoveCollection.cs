namespace Collection.Models
{
    using Collection.Models.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class AddRemoveCollection : IAddRemoveCollection
    {
        private List<string> items;

        public IReadOnlyCollection<string> Items { get => this.items.AsReadOnly(); }

        public AddRemoveCollection()
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
            if(this.items.Count > 0)
            {
                ret = this.items[this.items.Count - 1];
                this.items.RemoveAt(this.items.Count - 1);
            }

            return ret;
        }
    }
}
