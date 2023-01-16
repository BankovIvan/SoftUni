namespace ChristmasPastryShop.Models.Delicacies
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Gingerbread : Delicacy
    {
        private const double gignerbreadPrice = 4.00;

        public Gingerbread(string delicacyName) : 
            base(delicacyName, gignerbreadPrice)
        {
        }

    }
}
