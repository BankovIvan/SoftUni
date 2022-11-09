namespace _Explicit.Models.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    internal interface IPerson
    {
        string Name { get; set; }
        int Age { get; set; }

        string GetName();

    }
}
