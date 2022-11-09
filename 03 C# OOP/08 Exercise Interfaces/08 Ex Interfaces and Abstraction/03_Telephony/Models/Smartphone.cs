namespace Telephony.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Telephony.Models.Exceptions;
    using Telephony.Models.Interfaces;

    public class Smartphone : ISmartphone
    {
        public Smartphone()
        {

        }

        public string BroseURL(string url)
        {
            StringBuilder ret = new StringBuilder();

            if(!ValidateURL(url))
            {
                throw new InvalidURLException();
            }

            ret.AppendLine(String.Format("Browsing: {0}!", url));

            return ret.ToString().Trim();
        }

        public string Call(string phoneNumber)
        {
            StringBuilder ret = new StringBuilder();

            if (!ValidatePhoneNumber(phoneNumber))
            {
                throw new InvalidPhoneNumberException();
            }

            ret.AppendLine(String.Format("Calling... {0}", phoneNumber));

            return ret.ToString().Trim();
        }

        private bool ValidatePhoneNumber(string phoneNumber)
            => phoneNumber.All(ch => char.IsDigit(ch));

        private bool ValidateURL(string url)
            => url.All(ch => !char.IsDigit(ch));

    }
}
