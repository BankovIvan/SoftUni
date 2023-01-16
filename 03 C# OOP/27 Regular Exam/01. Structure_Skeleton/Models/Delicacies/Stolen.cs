namespace ChristmasPastryShop.Models.Delicacies
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Stolen : Delicacy
    {
        private const double gignerbreadPrice = 3.50;

        public Stolen(string delicacyName) :
            base(delicacyName, gignerbreadPrice)
        {
        }
    }
}
