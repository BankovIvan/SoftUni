using System;

namespace _01._Excursion
{
    class Program
    {
        static void Main(string[] args)
        {

            int nPeoplesAmount = 0, nNightsAmount = 0, nCardsAmount = 0, nTicketsAmount = 0;
            double nTotalMoney = 0.0;

            nPeoplesAmount = int.Parse(Console.ReadLine());
            nNightsAmount = int.Parse(Console.ReadLine());
            nCardsAmount = int.Parse(Console.ReadLine());
            nTicketsAmount = int.Parse(Console.ReadLine());

            nTotalMoney = (double)nNightsAmount * 20.0;
            nTotalMoney += (double)nCardsAmount * 1.6;
            nTotalMoney += nTicketsAmount * 6.0;
            nTotalMoney *= (double)nPeoplesAmount;

            nTotalMoney += nTotalMoney * 0.25;

            Console.WriteLine("{0:F2}", nTotalMoney);

        }
    }
}
