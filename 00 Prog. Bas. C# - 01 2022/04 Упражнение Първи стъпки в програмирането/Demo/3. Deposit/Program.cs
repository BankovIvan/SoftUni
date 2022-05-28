using System;

namespace _3._Deposit
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");

            double dDeposit, dDuration, dInterest, dReturn;

            dDeposit = double.Parse(Console.ReadLine());
            dDuration = double.Parse(Console.ReadLine());
            dInterest = double.Parse(Console.ReadLine());

            dReturn = dDeposit + (dDeposit * dInterest / 100) * (dDuration / 12);

            Console.WriteLine(dReturn);

        }
    }
}
