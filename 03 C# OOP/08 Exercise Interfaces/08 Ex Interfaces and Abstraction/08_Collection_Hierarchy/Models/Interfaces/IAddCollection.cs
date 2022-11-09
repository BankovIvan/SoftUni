namespace Collection.Models.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IAddCollection
    {
        IReadOnlyCollection<string> Items { get; }

        int Add(string item);
    }
}
