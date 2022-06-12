using System;

namespace _11_Math_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            double dNum1, dNum2;
            string @operator;

            dNum1 = double.Parse(Console.ReadLine());
            @operator = Console.ReadLine();
            dNum2 = double.Parse(Console.ReadLine());

            Console.WriteLine(MyCalculate(dNum1, @operator, dNum2));

        }

        private static double MyCalculate(double dNum1, string @operator, double dNum2)
        {
            double dRet = 0.00;

            switch (@operator)
            {
                case "/":
                    dRet = dNum1 / dNum2;
                    break;

                case "*":
                    dRet = dNum1 * dNum2;
                    break;

                case "+":
                    dRet = dNum1 + dNum2;
                    break;

                default:
                    dRet = dNum1 - dNum2;
                    break;
            }

            return dRet;

        }
    }
}
