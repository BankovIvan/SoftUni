namespace _01_Recursive_Array_Sum
{
    using System;

    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arrInput = Array.ConvertAll(
                Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries),
                new Converter<string, int>(int.Parse));


            Console.WriteLine(funcSumAllRecursively(arrInput, 0));

        }

        public static int funcSumAllRecursively(int[] arrData, int index)
        {
            int ret = 0;

            if (index == arrData.Length)
            {
                return ret;
            }

            ret = arrData[index];
            index++;

            ret += funcSumAllRecursively(arrData, index);

            return ret;
        }

    }
}
