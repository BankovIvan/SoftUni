namespace ChristmasPastryShop.Core
{
    using ChristmasPastryShop.Core.Contracts;
    using ChristmasPastryShop.Models.Booths;
    using ChristmasPastryShop.Models.Booths.Contracts;
    using ChristmasPastryShop.Models.Cocktails;
    using ChristmasPastryShop.Models.Cocktails.Contracts;
    using ChristmasPastryShop.Models.Delicacies;
    using ChristmasPastryShop.Models.Delicacies.Contracts;
    using ChristmasPastryShop.Repositories;
    using ChristmasPastryShop.Repositories.Contracts;
    using ChristmasPastryShop.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Linq;
    using System.Drawing;

    public class Controller : IController
    {
        private IRepository<IBooth> booths;

        public Controller()
        {
            this.booths = new BoothRepository();
        }

        public string AddBooth(int capacity)
        {
            StringBuilder ret = new StringBuilder();

            int boothId = booths.Models.Count + 1;
            IBooth booth = new Booth(boothId, capacity);
            this.booths.AddModel(booth);

            ret.AppendLine(
                String.Format(
                    OutputMessages.NewBoothAdded,
                    booth.BoothId, booth.Capacity));

            return ret.ToString().Trim();
        }

        public string AddCocktail(int boothId, string cocktailTypeName, string cocktailName, string size)
        {
            StringBuilder ret = new StringBuilder();

            ICocktail cocktail;

            if (cocktailTypeName == "MulledWine")
            {
                cocktail = new MulledWine(cocktailName, size);
            }
            else if (cocktailTypeName == "Hibernation")
            {
                cocktail = new Hibernation(cocktailName, size);
            }
            else
            {
                ret.AppendLine(
                    String.Format(
                        OutputMessages.InvalidCocktailType,
                        cocktailTypeName));
                return ret.ToString().Trim();
            }

            foreach (var v in this.booths.Models)
            {
                if (v.BoothId == boothId)
                {
                    foreach (var c in v.CocktailMenu.Models)
                    {
                        if (!(size == "Large" || size == "Middle" || size == "Small"))
                        {
                            ret.AppendLine(
                                String.Format(
                                    OutputMessages.InvalidCocktailSize,
                                    size));
                            return ret.ToString().Trim();
                        }
                        if (c.Name == cocktailName && c.Size == size)
                        {
                            ret.AppendLine(
                                String.Format(
                                    OutputMessages.CocktailAlreadyAdded,
                                    cocktailName, size));
                            return ret.ToString().Trim();
                        }
                    }

                    v.CocktailMenu.AddModel(cocktail);
                    break;

                }
            }

            ret.AppendLine(
                String.Format(
                    OutputMessages.NewCocktailAdded,
                    cocktail.Size, cocktail.Name, cocktail.GetType().Name));

            return ret.ToString().Trim();
        }

        public string AddDelicacy(int boothId, string delicacyTypeName, string delicacyName)
        {
            StringBuilder ret = new StringBuilder();

            //int boothId = booths.Models.Count + 1;
            IDelicacy delicasy;

            if(delicacyTypeName == "Gingerbread")
            {
                delicasy = new Gingerbread(delicacyName);
            }
            else if(delicacyTypeName == "Stolen")
            {
                delicasy = new Stolen(delicacyName);
            }
            else
            {
                ret.AppendLine(
                    String.Format(
                        OutputMessages.InvalidDelicacyType,
                        delicacyTypeName));
                return ret.ToString().Trim();
            }

            foreach(var v in this.booths.Models)
            {
               if(v.BoothId == boothId)
                {
                    foreach(var d in v.DelicacyMenu.Models)
                    {
                        if(d.Name == delicacyName)
                        {
                            ret.AppendLine(
                                String.Format(
                                    OutputMessages.DelicacyAlreadyAdded,
                                    delicacyName));
                            return ret.ToString().Trim();
                        }
                    }

                    v.DelicacyMenu.AddModel(delicasy);
                    break;

                }
            }

            ret.AppendLine(
                String.Format(
                    OutputMessages.NewDelicacyAdded,
                    delicasy.GetType().Name, delicasy.Name));

            return ret.ToString().Trim();
        }

        public string BoothReport(int boothId)
        {

            IBooth booth = (IBooth)this.booths.Models.Where(x => x.BoothId == boothId).First();

            return booth.ToString();
        }

        public string LeaveBooth(int boothId)
        {
            StringBuilder ret = new StringBuilder();

            IBooth booth = (IBooth)this.booths.Models.Where(x => x.BoothId == boothId).First();

            double currentBill = booth.CurrentBill;

            booth.Charge();
            booth.ChangeStatus();

            ret.AppendLine(
                String.Format(
                    "Bill {0:F2} lv",
                    currentBill));
            ret.AppendLine(
                String.Format(
                    "Booth {0} is now available!",
                    booth.BoothId));

            return ret.ToString().Trim();
        }

        public string ReserveBooth(int countOfPeople)
        {
            StringBuilder ret = new StringBuilder();

            if(!this.booths.Models
                .Any(x => x.IsReserved == false && x.Capacity >= countOfPeople))
            {
                ret.AppendLine(
                    String.Format(
                        OutputMessages.NoAvailableBooth,
                        countOfPeople));
                return ret.ToString().Trim();
            }

            IBooth booth = (IBooth)this.booths.Models
                .Where(x => x.IsReserved == false && x.Capacity >= countOfPeople)
                .OrderBy(y => y.Capacity).ThenByDescending(z => z.BoothId)
                .First();

            if(booth == null)
            {
                ret.AppendLine(
                    String.Format(
                        OutputMessages.NoAvailableBooth,
                        countOfPeople));
                return ret.ToString().Trim();
            }

            booth.ChangeStatus();
            ret.AppendLine(
                String.Format(
                    OutputMessages.BoothReservedSuccessfully,
                    booth.BoothId, countOfPeople));
            return ret.ToString().Trim();


        }

        public string TryOrder(int boothId, string order)
        {
            StringBuilder ret = new StringBuilder();

            string[] orderData = order.Split('/');
            string itemTypeName = orderData[0];
            string itemName = orderData[1];
            int count = int.Parse(orderData[2]);
            //string size = "";

            //if(itemTypeName == "Hibernation" || itemTypeName == "MulledWine")
            //{
            //    size = orderData[3];
            //}

            if (!(itemTypeName == "Hibernation" || itemTypeName == "MulledWine" || 
                itemTypeName == "Gingerbread" || itemTypeName == "Stolen"))
            {
                ret.AppendLine(
                    String.Format(
                        OutputMessages.NotRecognizedType,
                        itemTypeName));
                return ret.ToString().Trim();
            }

            IBooth booth = (IBooth)this.booths.Models.Where(x => x.BoothId == boothId).First();

            if(!(
                booth.DelicacyMenu.Models.Any(x => x.Name == itemName) || 
                booth.CocktailMenu.Models.Any(x => x.Name == itemName)))
            {
                ret.AppendLine(
                    String.Format(
                        OutputMessages.NotRecognizedItemName,
                        itemTypeName, itemName));
                return ret.ToString().Trim();
            }

            if (itemTypeName == "Hibernation" || itemTypeName == "MulledWine")
            {
                string size = orderData[3];

                if(!booth.CocktailMenu.Models.Any(
                                        x => x.GetType().Name == itemTypeName &&
                                        x.Name == itemName &&
                                        x.Size == size))
                {
                    ret.AppendLine(
                        String.Format(
                            OutputMessages.NotRecognizedItemName,
                            size, itemName));
                    return ret.ToString().Trim();
                }

                ICocktail cocktail = (ICocktail)booth.CocktailMenu.Models.Where(
                                        x => x.GetType().Name == itemTypeName &&
                                        x.Name == itemName &&
                                        x.Size == size).First();

                booth.UpdateCurrentBill(cocktail.Price * count);

            }
            else
            {
                if (!booth.DelicacyMenu.Models.Any(
                        x => x.GetType().Name == itemTypeName &&
                        x.Name == itemName))
                {
                    ret.AppendLine(
                        String.Format(
                            OutputMessages.NotRecognizedItemName,
                            itemTypeName, itemName));
                    return ret.ToString().Trim();
                }

                IDelicacy delicasy = (IDelicacy)booth.DelicacyMenu.Models.Where(
                                        x => x.GetType().Name == itemTypeName &&
                                        x.Name == itemName).First();

                booth.UpdateCurrentBill(delicasy.Price * count);

            }

            ret.AppendLine(
                String.Format(
                    OutputMessages.SuccessfullyOrdered,
                    booth.BoothId, count, itemName));
            return ret.ToString().Trim();
        }
    }
}
