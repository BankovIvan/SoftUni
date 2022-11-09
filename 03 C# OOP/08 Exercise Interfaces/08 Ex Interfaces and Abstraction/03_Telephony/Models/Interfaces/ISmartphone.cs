namespace Telephony.Models.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface ISmartphone : IStationaryPhone
    {
        public string BroseURL(string url);
    }
}
