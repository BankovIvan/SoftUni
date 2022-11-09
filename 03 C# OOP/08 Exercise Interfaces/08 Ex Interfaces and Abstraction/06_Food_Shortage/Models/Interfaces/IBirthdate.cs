namespace Food.Models.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IBirthdate
    {
        public DateTime Birthday { get; set; }

        public bool IsBirthYear(int year);

    }
}
