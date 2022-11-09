namespace Telephony.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Telephony.Models.Exceptions;
    using Telephony.Models.Interfaces;

    public class StationaryPhone : IStationaryPhone
    {
        public StationaryPhone()
        {

        }

        public string Call(string phoneNumber)
        {
            StringBuilder ret = new StringBuilder();

            if (!ValidatePhoneNumber(phoneNumber))
            {
                throw new InvalidPhoneNumberException();
            }

            ret.AppendLine(String.Format("Dialing... {0}", phoneNumber));

            return ret.ToString().Trim();
        }

        private bool ValidatePhoneNumber(string phoneNumber)
        {
            bool ret = !string.IsNullOrEmpty(phoneNumber);

            if(ret == true)
            {
                foreach (var v in phoneNumber)
                {
                    if (!char.IsDigit(v))
                    {
                        ret = false;
                        break;
                    }
                }
            }

            return ret;
        }

    }
}
