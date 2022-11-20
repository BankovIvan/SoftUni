namespace Logger.Core.Utilities
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Text;

    public static class DateTimeValidator
    {
        private static ICollection<string> ALLOWED_DATETIME_FORMATS = 
            new HashSet<string>(new string[] {
            "MM/dd/yyyy hh:mm:ss tt",
            "MM/dd/yyyy HH:mm:ss",
            "M/dd/yyyy h:mm:ss tt"
        });

        public static bool IsDateTimeValid(string dateTime)
        {
            bool ret = false;
            DateTime d;

            foreach (var v in ALLOWED_DATETIME_FORMATS)
            {
                if (DateTime.TryParseExact(dateTime, v, CultureInfo.InvariantCulture, DateTimeStyles.None, out d))
                {
                    ret = true;
                    break;
                }
            }

            return ret;

        }

        public static void RegisterNewFormat(string newFormat)
        {
            ALLOWED_DATETIME_FORMATS.Add(newFormat);
        }
    
    }
}
