using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    public static int[] H;

    static void Main(string[] args)
    {
        int i, stack_top;
        long currArea, maxArea = 0;
        Stack<int> histogram = new Stack<int>();

        H = Console.ReadLine().Split().Select(int.Parse).ToArray();

        for(i = 0; i < H.Length; i++)
        {
            while (histogram.Count > 1 && H[histogram.Peek()] > H[i])
            {
                stack_top = histogram.Pop();
                currArea = H[stack_top] * (i - histogram.Peek() - 1);
                if (maxArea < currArea)
                {
                    maxArea = currArea;
                }
            }

            if (histogram.Count > 0 && H[histogram.Peek()] > H[i])
            {
                stack_top = histogram.Pop();
                currArea = H[stack_top] * i;
                if (maxArea < currArea)
                {
                    maxArea = currArea;
                }
            }

            histogram.Push(i);
        }

        //Last element H[H.Length - 1]...
        while (histogram.Count > 1)
        {
            stack_top = histogram.Pop();
            currArea = H[stack_top] * (i - histogram.Peek() - 1);
            if (maxArea < currArea)
            {
                maxArea = currArea;
            }
        }

        if (histogram.Count > 0)
        {
            stack_top = histogram.Pop();
            currArea = H[stack_top] * i;
            if (maxArea < currArea)
            {
                maxArea = currArea;
            }
        }

        Console.WriteLine(maxArea);

        return;

    }
}
