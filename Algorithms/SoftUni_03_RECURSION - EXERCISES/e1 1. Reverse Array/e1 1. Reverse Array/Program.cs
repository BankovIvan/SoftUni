using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static void Main(string[] args)
    {

        int[] numbers;
 //       Stack<int> result = new Stack<int>();

        numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        ReverseNumbers1(numbers, 0);
        //ReverseNumbers2(numbers, result, 0);

        //Console.WriteLine(string.Concat(numbers));
        Console.WriteLine(string.Join(" ", numbers));
        //Console.WriteLine(string.Join(" ", result));
        return;

    }

    private static void ReverseNumbers2(int[] numbers, Stack<int> result, int idx)
    {
        if (idx >= 0 && idx <= numbers.GetUpperBound(0))
        {
            result.Push(numbers[idx]);
            ReverseNumbers2(numbers, result, ++idx);

        }

        return;

    }

    private static void ReverseNumbers1(int[] numbers, int index)
    {
        int tmp;
        int len = numbers.GetUpperBound(0);


        if(index >= 0 && index <= (len / 2))
        {
            tmp = numbers[index];
            numbers[index] = numbers[len - index];
            numbers[len - index] = tmp;
            ReverseNumbers1(numbers, ++index);

        }

        return;
    }
}



