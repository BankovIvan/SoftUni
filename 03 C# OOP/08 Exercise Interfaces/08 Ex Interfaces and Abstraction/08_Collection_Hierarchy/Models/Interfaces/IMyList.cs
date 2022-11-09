namespace Collection.Models.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IMyList : IAddRemoveCollection
    {
        int Used { get; }
    }
}
