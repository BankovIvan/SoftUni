namespace Telephony.Models.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IStationaryPhone
    {
        public string Call(string phoneNumber);
    }
}
