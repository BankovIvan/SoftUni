using System;

namespace _03_Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            int nPeopleCount;
            string sGroupType, sWeekDay;
            double dTotalPay;

            nPeopleCount = int.Parse(Console.ReadLine());
            sGroupType = Console.ReadLine();
            sWeekDay = Console.ReadLine();
            dTotalPay = 0.0;

            if(sGroupType== "Students")
            {
                if(sWeekDay == "Friday")
                {
                    dTotalPay = 8.45;
                }
                else if (sWeekDay == "Saturday")
                {
                    dTotalPay = 9.80;
                }
                else if (sWeekDay == "Sunday")
                {
                    dTotalPay = 10.46;
                }

                dTotalPay *= (double)nPeopleCount;

                if (nPeopleCount >= 30)
                {
                    dTotalPay *= 0.85;
                }

            }
            else if (sGroupType == "Business")
            {
                if (sWeekDay == "Friday")
                {
                    dTotalPay = 10.90;
                }
                else if (sWeekDay == "Saturday")
                {
                    dTotalPay = 15.60;
                }
                else if (sWeekDay == "Sunday")
                {
                    dTotalPay = 16.0;
                }

                if (nPeopleCount >= 100)
                {
                    dTotalPay *= (double)(nPeopleCount - 10);
                }
                else
                {
                    dTotalPay *= (double)nPeopleCount;
                }

            }
            else if (sGroupType == "Regular")
            {
                if (sWeekDay == "Friday")
                {
                    dTotalPay = 15.0;
                }
                else if (sWeekDay == "Saturday")
                {
                    dTotalPay = 20.0;
                }
                else if (sWeekDay == "Sunday")
                {
                    dTotalPay = 22.50;
                }

                dTotalPay *= (double)nPeopleCount;

                if (nPeopleCount >= 10 && nPeopleCount <= 20)
                {
                    dTotalPay *= 0.95;
                }

            }

            Console.WriteLine("Total price: {0:F2}", dTotalPay);

        }
    }
}
