using System;

namespace _11._Fruit_Shop
{
    class Program
    {
        static void Main(string[] args)
        {

            string sProductIn, sWeekDayIn;
            double dQuantityIn, dPrice;

            sProductIn = Console.ReadLine();
            sWeekDayIn = Console.ReadLine();
            dQuantityIn = double.Parse(Console.ReadLine());
            dPrice = -1.0;

            switch (sProductIn)
            {
                case "banana":

                    if(sWeekDayIn == "Monday" || sWeekDayIn == "Tuesday" || sWeekDayIn == "Wednesday" || 
                        sWeekDayIn == "Thursday" || sWeekDayIn == "Friday")
                    {
                        dPrice = 2.50;
                    }
                    else if (sWeekDayIn == "Saturday" || sWeekDayIn == "Sunday")
                    {
                        dPrice = 2.70;
                    }

                    break;

                case "apple":

                    if (sWeekDayIn == "Monday" || sWeekDayIn == "Tuesday" || sWeekDayIn == "Wednesday" ||
                        sWeekDayIn == "Thursday" || sWeekDayIn == "Friday")
                        {
                        dPrice = 1.20;
                    }
                        else if (sWeekDayIn == "Saturday" || sWeekDayIn == "Sunday")
                        {
                        dPrice = 1.25;
                    }

                    break;

                case "orange":

                    if (sWeekDayIn == "Monday" || sWeekDayIn == "Tuesday" || sWeekDayIn == "Wednesday" ||
                        sWeekDayIn == "Thursday" || sWeekDayIn == "Friday")
                    {
                        dPrice = 0.85;
                    }
                    else if (sWeekDayIn == "Saturday" || sWeekDayIn == "Sunday")
                    {
                        dPrice = 0.90;
                    }

                    break;

                case "grapefruit":

                    if (sWeekDayIn == "Monday" || sWeekDayIn == "Tuesday" || sWeekDayIn == "Wednesday" ||
                        sWeekDayIn == "Thursday" || sWeekDayIn == "Friday")
                    {
                        dPrice = 1.45;
                    }
                    else if (sWeekDayIn == "Saturday" || sWeekDayIn == "Sunday")
                    {
                        dPrice = 1.60;
                    }

                    break;

                case "kiwi":

                    if (sWeekDayIn == "Monday" || sWeekDayIn == "Tuesday" || sWeekDayIn == "Wednesday" ||
                        sWeekDayIn == "Thursday" || sWeekDayIn == "Friday")
                    {
                        dPrice = 2.70;
                    }
                    else if (sWeekDayIn == "Saturday" || sWeekDayIn == "Sunday")
                    {
                        dPrice = 3.00;
                    }

                    break;

                case "pineapple":

                    if (sWeekDayIn == "Monday" || sWeekDayIn == "Tuesday" || sWeekDayIn == "Wednesday" ||
                        sWeekDayIn == "Thursday" || sWeekDayIn == "Friday")
                    {
                        dPrice = 5.50;
                    }
                    else if (sWeekDayIn == "Saturday" || sWeekDayIn == "Sunday")
                    {
                        dPrice = 5.60;
                    }

                    break;

                case "grapes":

                    if (sWeekDayIn == "Monday" || sWeekDayIn == "Tuesday" || sWeekDayIn == "Wednesday" ||
                        sWeekDayIn == "Thursday" || sWeekDayIn == "Friday")
                    {
                        dPrice = 3.85;
                    }
                    else if (sWeekDayIn == "Saturday" || sWeekDayIn == "Sunday")
                    {
                        dPrice = 4.20;
                    }

                    break;

                default:

                    break;
            }

            if(dPrice >= 0.0)
            {
                Console.WriteLine("{0:F2}", dQuantityIn * dPrice);
            }
            else
            {
                Console.WriteLine("error");
            }

        }
    }
}
