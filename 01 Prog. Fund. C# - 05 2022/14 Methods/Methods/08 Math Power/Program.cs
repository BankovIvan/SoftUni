using System;

namespace _08_Math_Power
{
    class Program
    {
        static void Main(string[] args)
        {
            double dBase;
            int nPower;

            dBase = double.Parse(Console.ReadLine());
            nPower = int.Parse(Console.ReadLine());

            Console.WriteLine(MyPowerCalc(dBase, nPower));

        }

        private static double MyPowerCalc(double dBase, int nPower)
        {
            double dRet = 1;
            int i;

            for(i = 0; i < nPower; i++)
            {
                dRet *= dBase;
            }

            return dRet;

        }
    }
}
