using System;

namespace _08_Condense_Array_to_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arrCondensedSums;
            int index, i;

            arrCondensedSums = Array.ConvertAll(
                            Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries), 
                            new Converter<string, int>(int.Parse)
                                                );

            index = arrCondensedSums.Length - 1;
            for(; index > 0; index--)
            {
                for(i = 0; i < index; i++)
                {
                    arrCondensedSums[i] = arrCondensedSums[i] + arrCondensedSums[i+1];
                }
            }

            Console.WriteLine(arrCondensedSums[0]);

        }
    }
}
