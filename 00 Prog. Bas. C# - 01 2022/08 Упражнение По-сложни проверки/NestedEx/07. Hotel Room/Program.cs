using System;

namespace _07._Hotel_Room
{
    class Program
    {
        static void Main(string[] args)
        {

            string sMonthIn;
            int nNightsIn;
            double dApartmentPrice, dStudioPrice;

            sMonthIn = Console.ReadLine();
            nNightsIn = int.Parse(Console.ReadLine());
            dApartmentPrice = 0.0;
            dStudioPrice = 0.0;

            switch (sMonthIn)
            {

                case "May":

                case "October":

                    dStudioPrice = (double)nNightsIn * 50.0;
                    dApartmentPrice = (double)nNightsIn * 65.0;

                    if(nNightsIn > 14)
                    {
                        dStudioPrice *= 0.70;
                        dApartmentPrice *= 0.90;
                    }
                    else if (nNightsIn > 7)
                    {
                        dStudioPrice *= 0.95;
                    }

                    break;

                case "June":

                case "September":

                    dStudioPrice = (double)nNightsIn * 75.20;
                    dApartmentPrice = (double)nNightsIn * 68.70;

                    if (nNightsIn > 14)
                    {
                        dStudioPrice *= 0.80;
                        dApartmentPrice *= 0.90;
                    }

                    break;

                case "July":

                case "August":

                    dStudioPrice = (double)nNightsIn * 76.0;
                    dApartmentPrice = (double)nNightsIn * 77.0;

                    if (nNightsIn > 14)
                    {
                        dApartmentPrice *= 0.90;
                    }

                    break;

                default:

                    break;
            }

            Console.WriteLine("Apartment: {0:F2} lv.", dApartmentPrice);
            Console.WriteLine("Studio: {0:F2} lv.", dStudioPrice);

        }
    }
}
