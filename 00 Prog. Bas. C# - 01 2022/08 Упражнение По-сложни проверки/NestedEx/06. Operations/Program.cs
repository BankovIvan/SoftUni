using System;

namespace _06._Operations
{
    class Program
    {
        static void Main(string[] args)
        {

            long nN1, nN2, nResult;
            string sOperator, sParity;

            nN1 = int.Parse(Console.ReadLine());
            nN2 = int.Parse(Console.ReadLine());
            sOperator = Console.ReadLine();
            nResult = 0;
            sParity = "even";

            switch (sOperator)
            {
                case "+":

                    nResult = nN1 + nN2;

                    if (nResult % 2 == 1)
                    {
                        sParity = "odd";
                    }

                    Console.WriteLine("{0} + {1} = {2} - {3}", nN1, nN2, nResult, sParity);

                    break;

                case "-":

                    nResult = nN1 - nN2;

                    if (nResult % 2 != 0)
                    {
                        sParity = "odd";
                    }

                    Console.WriteLine("{0} - {1} = {2} - {3}", nN1, nN2, nResult, sParity);

                    break;

                case "*":

                    nResult = nN1 * nN2;

                    if (nResult % 2 == 1)
                    {
                        sParity = "odd";
                    }

                    Console.WriteLine("{0} * {1} = {2} - {3}", nN1, nN2, nResult, sParity);

                    break;

                case "/":

                    if (nN2 == 0)
                    {
                        Console.WriteLine($"Cannot divide {nN1} by zero");
                        return;
                    }

                    Console.WriteLine("{0} / {1} = {2:F2}", nN1, nN2, ((double)nN1 / (double)nN2));
                    //Console.WriteLine("{0} / {1} = {2:F2}", nN1, nN2, 0);

                    break;

                case "%":

                    if (nN2 == 0)
                    {
                        Console.WriteLine($"Cannot divide {nN1} by zero");
                        return;
                    }

                    nResult = nN1 % nN2;

                    Console.WriteLine("{0} % {1} = {2}", nN1, nN2, nResult);

                    break;

                default:

                    break;
            }


        }
    }
}
