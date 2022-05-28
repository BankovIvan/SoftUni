using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        int i, j, k, N, tmp = 0, total = 0;
        List<int> allX, allY;
        int[] data;
        int[,] rectangles;

        N = int.Parse(Console.ReadLine());
        allX = new List<int>();
        allY = new List<int>();
        rectangles = new int[N, 4];

        for (i = 0; i < N; i++)
        {
            Console.Write("    ");
            data = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            if (!allX.Contains(data[0])) allX.Add(data[0]);
            if (!allX.Contains(data[1])) allX.Add(data[1]);
            if (!allY.Contains(data[2])) allY.Add(data[2]);
            if (!allY.Contains(data[3])) allY.Add(data[3]);

            rectangles[i, 0] = data[0];
            rectangles[i, 1] = data[1];
            rectangles[i, 2] = data[2];
            rectangles[i, 3] = data[3];

        }

        allX.Sort();
        allY.Sort();

        for(i = 1; i < allX.Count; i++)
        {
            for (j = 1; j < allY.Count; j++)
            {
                tmp = 0;
                for(k = 0; k < N; k++)
                {
                    if (rectangles[k, 0] < allX[i] && 
                        rectangles[k, 1] > allX[i - 1] && 
                        rectangles[k, 2] < allY[j] && 
                        rectangles[k, 3] > allY[j - 1])
                    {
                        tmp++;
                        if(tmp > 1)
                        {
                            total = total + ((allX[i] - allX[i - 1]) * (allY[j] - allY[j - 1]));
                            break;
                        }
                    }
                }
            }
        }

        Console.WriteLine(total);

        return;

    }

}
