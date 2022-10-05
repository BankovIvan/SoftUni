namespace DefiningClasses
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class DateModifier
    {
        private int dateDiff;
        
        public int DateDiff { get { return this.dateDiff; } set { this.dateDiff = value; } }

        public DateModifier()
        {
            DateDiff = 0;
        }

        public DateModifier(string date1, string date2)
        {
            DateTime days1 = DateTime.ParseExact(date1, "yyyy MM dd", System.Globalization.CultureInfo.InvariantCulture);
            DateTime days2 = DateTime.ParseExact(date2, "yyyy MM dd", System.Globalization.CultureInfo.InvariantCulture);

            DateDiff = Math.Abs((int)(days2 - days1).TotalDays);
        }


    }
}
