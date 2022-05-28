using System;

namespace _09._Ski_Trip
{
    class Program
    {
        static void Main(string[] args)
        {

            int nDaysSatyIn;
            string sRoomTypeIn, sGradeIn ;
            double dPrice;

            nDaysSatyIn = int.Parse(Console.ReadLine());
            sRoomTypeIn = Console.ReadLine();
            sGradeIn = Console.ReadLine();
            dPrice = 0.0;

            nDaysSatyIn -= 1;

            switch (sRoomTypeIn)
            {
                case "room for one person":

                    dPrice = (double)nDaysSatyIn * 18.00;

                    break;

                case "apartment":

                    dPrice = (double)nDaysSatyIn * 25.00;

                    if(nDaysSatyIn > 15)
                    {
                        dPrice *= 0.50;
                    }
                    else if(nDaysSatyIn >= 10)
                    {
                        dPrice *= 0.65;
                    }
                    else
                    {
                        dPrice *= 0.70;
                    }

                    break;

                case "president apartment":

                    dPrice = (double)nDaysSatyIn * 35.00;

                    if (nDaysSatyIn > 15)
                    {
                        dPrice *= 0.80;
                    }
                    else if (nDaysSatyIn >= 10)
                    {
                        dPrice *= 0.85;
                    }
                    else
                    {
                        dPrice *= 0.90;
                    }

                    break;

                default:

                    break;
            }

            if(sGradeIn == "positive")
            {
                dPrice *= 1.25;
            }
            else
            {
                dPrice *= 0.90;
            }

            Console.WriteLine("{0:F2}", dPrice);

        }
    }
}
