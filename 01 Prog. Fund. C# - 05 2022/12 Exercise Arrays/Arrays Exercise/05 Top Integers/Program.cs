using System;

namespace _05_Top_Integers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arrTopIntegers;
            int i, j;
            bool bTop;

            arrTopIntegers = Array.ConvertAll(
                            Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries),
                            new Converter<string, int>(int.Parse)
                                                );

            for(i = 0; i < arrTopIntegers.Length; i++)
            {
                bTop = true;

                for (j = i + 1; j < arrTopIntegers.Length; j++)
                {
                    if(arrTopIntegers[i] <= arrTopIntegers[j])
                    {
                        bTop = false;
                        break;
                    }
                }

                if (bTop == true)
                {
                    Console.Write("{0} ", arrTopIntegers[i]);
                }

            }

            Console.WriteLine();

        }
    }
}
