namespace ChristmasPastryShop.Models.Cocktails
{
    using ChristmasPastryShop.Models.Cocktails.Contracts;
    using ChristmasPastryShop.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class Cocktail : ICocktail
    {
        private const double SIZE_MODIFIER_LARGE = 1.00;
        private const double SIZE_MODIFIER_MIDDLE = 2.00 / 3.00;
        private const double SIZE_MODIFIER_SMALL = 1.00 / 3.00;

        private string name;
        private string size;
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

        public string Size
        {
            get { return size; }
            private set { size = value; }
        }

        public double Price
        {
            get { return price; }
            private set 
            {
                double modifier = -1.00;
                
                if(this.Size == "Large")
                {
                    modifier = SIZE_MODIFIER_LARGE;
                }
                else if(this.Size == "Middle")
                {
                    modifier = SIZE_MODIFIER_MIDDLE;
                }
                else if (this.Size == "Small")
                {
                    modifier = SIZE_MODIFIER_SMALL;
                }

                this.price = modifier * value;
            }
        }

        public Cocktail(string cocktailName, string size, double price)
        {
            this.Name = cocktailName;
            this.Size = size;
            this.Price = price;
        }

        public override string ToString()
        {
            StringBuilder ret = new StringBuilder();

            ret.AppendLine(
                string.Format(
                    "{0} ({1}) - {2:F2} lv",
                    this.Name, this.Size, this.Price));

            return ret.ToString().Trim();
        }
    }
}
