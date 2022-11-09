namespace Military.Models.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface ISoldier
    {
        long Id { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
    }
}
