namespace ChristmasPastryShop.Models.Delicacies
{
    using ChristmasPastryShop.Models.Delicacies.Contracts;
    using ChristmasPastryShop.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class Delicacy : IDelicacy
    {
        private string name;
        private double price;

        public string Name
        {
            get { return name; }
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(
                        string.Format(
                            ExceptionMessages.NameNullOrWhitespace));
                }
                name = value; 
            }
        }

        public double Price
        {
            get { return price; }
            private set { price = value; }
        }

        public Delicacy(string delicacyName, double price)
        {
            this.Name = delicacyName;
            this.Price = price;
        }

        public override string ToString()
        {
            StringBuilder ret = new StringBuilder();

            ret.AppendLine(
                string.Format(
                    "{0} - {1:F2} lv",
                    this.Name, this.Price));

            return ret.ToString().Trim();
        }

    }
}
