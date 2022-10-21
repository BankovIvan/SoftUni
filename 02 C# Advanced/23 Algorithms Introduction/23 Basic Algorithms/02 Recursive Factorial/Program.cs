namespace _02_Recursive_Factorial
{
    using System;
    using System.Numerics;

    internal class Program
    {
        static void Main(string[] args)
        {
            BigInteger n = BigInteger.Parse(Console.ReadLine());

            Console.WriteLine(FactorialRecursive(n));
        }

        public static BigInteger FactorialRecursive(BigInteger n)
        {
            BigInteger ret = 0;

            if(n <= 1)
            {
                ret = 1;
            }
            else
            {
                ret = n;
                n--;
                ret *= FactorialRecursive(n);
            }

            return ret;

        }
    }
}
