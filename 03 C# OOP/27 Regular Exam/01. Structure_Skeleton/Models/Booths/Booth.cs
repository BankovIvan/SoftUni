namespace ChristmasPastryShop.Models.Booths
{
    using ChristmasPastryShop.Models.Booths.Contracts;
    using ChristmasPastryShop.Models.Cocktails.Contracts;
    using ChristmasPastryShop.Models.Delicacies.Contracts;
    using ChristmasPastryShop.Repositories;
    using ChristmasPastryShop.Repositories.Contracts;
    using ChristmasPastryShop.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Booth : IBooth
    {
        private int boothId;
        private int capacity;
        private IRepository<IDelicacy> delicacyMenu;
        private IRepository<ICocktail> cocktailMenu;
        private double currentBill;
        private double turnover;
        private bool isReserved;

        public int BoothId
        {
            get { return boothId; }
            private set { boothId = value; }
        }

        public int Capacity
        {
            get { return capacity; }
            private set 
            { 
                if(value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.CapacityLessThanOne);
                }
                capacity = value; 
            }
        }

        public IRepository<IDelicacy> DelicacyMenu
        {
            get { return delicacyMenu; }
            private set { delicacyMenu = value;}
        }

        public IRepository<ICocktail> CocktailMenu
        {
            get { return cocktailMenu; }
            private set { cocktailMenu = value;}
        }

        public double CurrentBill
        {
            get { return currentBill; }
            private set { currentBill = value; }   
        }

        public double Turnover
        {
            get { return turnover; }
            private set { turnover = value; }
        }

        public bool IsReserved
        {
            get { return isReserved; }
            private set { isReserved = value; }
        }

        private Booth()
        {
            this.CurrentBill = 0.00;
            this.Turnover = 0.00;
            this.IsReserved = false;
            this.DelicacyMenu = new DelicacyRepository();
            this.CocktailMenu = new CocktailRepository();
        }

        public Booth(int boothId, int capacity) : this()
        {
            this.BoothId = boothId;
            this.Capacity = capacity;
        }

        public void ChangeStatus()
        {
            this.IsReserved = !this.IsReserved;
        }

        public void Charge()
        {
            this.Turnover += this.CurrentBill;
            this.CurrentBill = 0.00;
        }

        public void UpdateCurrentBill(double amount)
        {
            this.CurrentBill += amount;
        }

        public override string ToString()
        {
            StringBuilder ret = new StringBuilder();

            ret.AppendLine(String.Format("Booth: {0}", this.BoothId));
            ret.AppendLine(String.Format("Capacity: {0}", this.Capacity));
            ret.AppendLine(String.Format("Turnover: {0:F2} lv", this.Turnover));
            ret.AppendLine(String.Format("-Cocktail menu:"));
            foreach(var v in this.CocktailMenu.Models)
            {
                ret.AppendLine(String.Format("--{0}", v.ToString()));
            }
            ret.AppendLine(String.Format("-Delicacy menu:"));
            foreach (var v in this.DelicacyMenu.Models)
            {
                ret.AppendLine(String.Format("--{0}", v.ToString()));
            }

            return ret.ToString().Trim();
        }



    }
}
