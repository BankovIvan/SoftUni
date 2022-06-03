using System;

namespace _07_Equal_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arrArray1, arrArray2;
            int nSum;

            arrArray1 = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            arrArray2 = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            nSum = 0;

            for(int i = 0; i < arrArray1.Length; i++)
            {
                if(arrArray1[i] != arrArray2[i])
                {
                    Console.WriteLine("Arrays are not identical. Found difference at {0} index", i);
                    return;
                }

                nSum += int.Parse(arrArray1[i]);
            }

            Console.WriteLine("Arrays are identical. Sum: {0}", nSum);

        }
    }
}
