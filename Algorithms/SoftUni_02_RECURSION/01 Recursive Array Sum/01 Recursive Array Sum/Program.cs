using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//namespace _01_Recursive_Array_Sum
//{
class Program
{
    static void Main(string[] args)
    {
        int[] numbers;

        numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        Console.WriteLine(Sum(numbers, 0));

    }

    private static long Sum(int[] numbers, int index)
    {
        if(index < numbers.Length -1)
        {
            return numbers[index] + Sum(numbers, index+1);

        }
        else
        {
            return numbers[index];
        }

    }
}
//}
