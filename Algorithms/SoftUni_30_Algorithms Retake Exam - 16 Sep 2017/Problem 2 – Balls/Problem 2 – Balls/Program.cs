using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    public static int balls;
    public static int pockets;
    public static int maxSize;
    public static int maxPut;
    public static int[] result;
    public static List<string> printResult = new List<string>();
    public static StringBuilder printOutput = new StringBuilder();

    static void Main(string[] args)
    {
        int i;

        ReadData();

        PutBallsRecursive(balls, 0);

        /*for (i = 0; i < printResult.Count; i++)
        {
            Console.WriteLine(printResult[i]);
        }*/

        Console.Write(printOutput);

        return;

    }

    private static void PutBallsRecursive(int currentBalls, int currentPocket)
    {
        if (currentPocket == result.Length - 1 && currentBalls == 0)
        {
            //Console.WriteLine(string.Join(", ", result));
            //printResult.Add(string.Join(", ", result));

            printOutput.AppendLine(string.Join(", ", result));

            return;
        }
        if (currentBalls < 1)
        {
            return;
        }
        if (currentPocket >= result.Length)
        {
            return;
        }
        if (result[currentPocket] > maxPut)
        {
            return;
        }
        if(result[currentPocket] < maxPut && currentBalls >= (result.Length - currentPocket))
        {
            result[currentPocket] = result[currentPocket] + 1;
            PutBallsRecursive(currentBalls - 1, currentPocket);
            result[currentPocket] = result[currentPocket] - 1;
        }
        if(result[currentPocket] > 0)
        {
            PutBallsRecursive(currentBalls, currentPocket + 1);
        }
    }

    private static void ReadData()
    {
        pockets = int.Parse(Console.ReadLine());
        balls = int.Parse(Console.ReadLine());
        maxSize = int.Parse(Console.ReadLine());

        maxPut = (balls - pockets) + 1;
        if(maxPut > maxSize)
        {
            maxPut = maxSize;
        }

        result = new int[pockets];
        //used = new bool[pockets];

        return;
    }
}
