namespace ValidationAttributes.Models.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IPerson
    {
        string FullName { get; }
        int Age { get; }
    }
}
