using System;

namespace _03._Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            
            double dVacationPrice = 0.0, dMoneyTotal = 0.0, dMoneySpent = 0.0;
            string sAction = "";
            int nSpendingCount = 0, nDaysTotal = 0; ;

            dVacationPrice = double.Parse(Console.ReadLine());
            dMoneyTotal = double.Parse(Console.ReadLine());

            while (dMoneyTotal < dVacationPrice)
            {
                sAction = Console.ReadLine();
                dMoneySpent = double.Parse(Console.ReadLine());
                nDaysTotal++;

                if (sAction == "save")
                {
                    dMoneyTotal += dMoneySpent;
                    nSpendingCount = 0;
                }
                else
                {
                    if(++nSpendingCount >= 5)
                    {
                        Console.WriteLine("You can't save the money.");
                        Console.WriteLine(nDaysTotal);
                        return;

                    }

                    dMoneyTotal -= dMoneySpent;
                    if(dMoneyTotal < 0)
                    {
                        dMoneyTotal = 0;
                    }


                }
            }

            Console.WriteLine("You saved the money for {0} days.", nDaysTotal);

        }
    }
}
