namespace Birthday.Models.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface ICitizen : IBirthdate
    {
        public string Name { get; set; }
        public int Age { get; set; }

    }
}
