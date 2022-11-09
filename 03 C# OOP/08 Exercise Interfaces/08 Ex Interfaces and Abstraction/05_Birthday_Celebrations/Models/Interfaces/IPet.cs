namespace Birthday.Models.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    internal interface IPet : IBirthdate
    {
        string Name { get; set; }
    }
}
