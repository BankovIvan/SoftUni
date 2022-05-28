using System;

namespace _01_Sort_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double dNum1, dNum2, dNum3, dNumTmp;

            dNum1 = double.Parse(Console.ReadLine());
            dNum2 = double.Parse(Console.ReadLine());
            dNum3 = double.Parse(Console.ReadLine());

            if (dNum2 < dNum3)
            {
                dNumTmp = dNum2;
                dNum2 = dNum3;
                dNum3 = dNumTmp;
            }

            if (dNum1 < dNum2)
            {
                dNumTmp = dNum1;
                dNum1 = dNum2;
                dNum2 = dNumTmp;
            }

            if (dNum2 < dNum3)
            {
                dNumTmp = dNum2;
                dNum2 = dNum3;
                dNum3 = dNumTmp;
            }


            Console.WriteLine(dNum1);
            Console.WriteLine(dNum2);
            Console.WriteLine(dNum3);

        }
    }
}
