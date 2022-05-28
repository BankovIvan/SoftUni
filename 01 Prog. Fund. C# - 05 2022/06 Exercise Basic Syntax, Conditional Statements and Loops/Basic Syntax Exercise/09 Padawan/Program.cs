using System;

namespace _09_Padawan
{
    class Program
    {
        static void Main(string[] args)
        {
            int nStudens;
            double nMoneyToal, nMoneyLighsaber, nMoneyBelt, nMoneyRobe, nMoneyOut;

            nMoneyToal = double.Parse(Console.ReadLine());
            nStudens = int.Parse(Console.ReadLine());
            nMoneyLighsaber = double.Parse(Console.ReadLine());
            nMoneyRobe = double.Parse(Console.ReadLine());
            nMoneyBelt = double.Parse(Console.ReadLine());

            //Lightsaber
            //nMoneyOut = nMoneyLighsaber * (double)nStudens;
            //nMoneyOut += nMoneyLighsaber * (double)Math.Ceiling((double)nStudens * 0.1);
            nMoneyOut = nMoneyLighsaber * Math.Ceiling((double)nStudens * 1.1);

            //Belt
            nMoneyOut += nMoneyBelt * (double)(nStudens - (nStudens / 6));

            //Robe
            nMoneyOut += nMoneyRobe * (double)nStudens;

            if(nMoneyToal >= nMoneyOut)
            {
                Console.WriteLine("The money is enough - it would cost {0:F2}lv.", nMoneyOut);
            }
            else
            {
                Console.WriteLine("John will need {0:F2}lv more.", nMoneyOut - nMoneyToal);
            }

        }
    }
}
