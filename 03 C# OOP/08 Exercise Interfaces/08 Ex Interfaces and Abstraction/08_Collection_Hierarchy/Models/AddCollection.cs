namespace Collection.Models
{
    using Collection.Models.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class AddCollection : IAddCollection
    {
        private List<string> items;

        public IReadOnlyCollection<string> Items { get => this.items.AsReadOnly(); }

        public AddCollection()
        {
            this.items = new List<string>();
        }

        public int Add(string item)
        {
            this.items.Add(item);
            return this.items.Count - 1;
        }
    }
}
