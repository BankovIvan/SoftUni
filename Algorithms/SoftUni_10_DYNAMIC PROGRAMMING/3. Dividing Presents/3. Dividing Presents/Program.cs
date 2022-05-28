using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static SortedDictionary<int, string> sumPresent = new SortedDictionary<int, string>();

    static void Main(string[] args)
    {
        
        string s = "";
        int index = 0;

        int[] presents = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        //int[] presents = { 3, 2, 3, 2, 2, 77, 89, 23, 90, 11 };
        //int[] presents = { 2, 2, 4, 4, 1, 1 };
        //int[] presents = { 7, 17, 45, 91, 11, 32, 102, 33, 6, 3 };

        int maxSum = presents.Sum();
        int middleSumDown = maxSum / 2;
        int middleSumUp = (maxSum + 1) / 2;

        int[] sumsMemo = Enumerable.Repeat(-1, maxSum + 1).ToArray(); //new int[maxSum + 1];
        sumsMemo[0] = 0;

        //SplitPresents1(presents);

        SplitPresents2(presents, sumsMemo, middleSumDown);

        while (middleSumDown >= 0)
        {
            if (sumsMemo[middleSumDown] != -1)
            {
                break;
            }
            else
            {
                middleSumDown--;
            }
        }

        index = middleSumDown;
        s = presents[sumsMemo[index]].ToString();
        index = index - presents[sumsMemo[index]];

        while (index > 0)
        {
            s = s + " " + presents[sumsMemo[index]].ToString();
            index = index - presents[sumsMemo[index]];
        }

        while (middleSumUp <= maxSum)
        {
            if (sumsMemo[middleSumUp] != -1)
            {
                break;
            }
            else
            {
                middleSumUp++;
            }
        }

        Console.WriteLine("Difference: {0}", middleSumUp - middleSumDown);
        Console.WriteLine("Alan:{0} Bob:{1}", middleSumDown, middleSumUp);
        Console.WriteLine("Alan takes: {0}", s);
        Console.WriteLine("Bob takes the rest.");

        return;

    }

    private static void SplitPresents2(int[] presents, int[] sumsMemo, int maxSum)
    {
        int i, j;

        for(i = 0; i < presents.Length; i++)
        {
            for(j = maxSum; j >= 0; j--)
            {
                if(sumsMemo[j] != -1 && sumsMemo[j + presents[i]] == -1)
                {
                    sumsMemo[j + presents[i]] = i;
                }
            }

        }


    }

    /*
    private static void SplitPresents1(int[] presents)
    {
        int i, j, newSum;
        int maxSum = presents.Sum();
        int middleSum = maxSum / 2;

        for (i = 0; i < presents.Length; i++)
        {

            if(sumPresent.Count > 0)
            {
                for (j = sumPresent.Last().Key; j > 0; j--)
                {

                    if (sumPresent.ContainsKey(j))
                    {
                        newSum = j + presents[i];
                        if (!sumPresent.ContainsKey(newSum))
                        {
                            sumPresent.Add(newSum, (newSum <= middleSum ? presents[i].ToString() + " " + sumPresent[j] : ""));
                        }
                    }

                }
            }


            if (!sumPresent.ContainsKey(presents[i]))
            {
                sumPresent.Add(presents[i], presents[i].ToString());
            }
            
        }

        return;
    }
    */

}
