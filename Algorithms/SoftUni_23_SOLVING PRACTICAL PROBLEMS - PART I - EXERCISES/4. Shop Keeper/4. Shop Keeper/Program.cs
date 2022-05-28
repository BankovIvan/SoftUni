using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        int i, j, currDistance, maxKey, total = 0;
        HashSet<int> stockList = new HashSet<int>();
        List<int> ordersList = new List<int>();
        Dictionary<int, int> distances = new Dictionary<int, int>();

        Console.Write("    ");
        foreach (var item in Console.ReadLine().Split(' '))
        {
            stockList.Add(int.Parse(item));
        }

        Console.Write("    ");
        foreach (var item in Console.ReadLine().Split(' '))
        {
            i = int.Parse(item);
            ordersList.Add(i);
        }

        for(i = 0; i < ordersList.Count; i++)
        {
            if (!distances.ContainsKey(ordersList[i]))
            {
                distances.Add(ordersList[i], ordersList.Count - i);
            }
        }

        foreach (var item in stockList)
        {
            if (!distances.ContainsKey(item))
            {
                distances.Add(item, 0);
            }
        }

        //Exit if not possible!
        //Only first pass check;
        if (!stockList.Contains(ordersList[0]))
        {
            Console.WriteLine("impossible");
            return;
        }

        //Cycle through list;
        for (i = 1; i < ordersList.Count; i++)
        {
            //If order item is contained within stock do nothing!

            //Update distance for previous order;
            distances[ordersList[i - 1]] = 0;
            for (j = i; j < ordersList.Count; j++)
            {
                if(ordersList[i - 1] == ordersList[j])
                {
                    distances[ordersList[i - 1]] = ordersList.Count - j;
                    break;
                }
            }

            if (!stockList.Contains(ordersList[i]))
            {
                //Find farthest stock item in the orders list...
                currDistance = int.MaxValue;
                maxKey = stockList.First();

                foreach (var item in stockList)
                {
                    if (currDistance > distances[item])
                    {
                        currDistance = distances[item];
                        maxKey = item;

                        if (currDistance == 0)
                        {
                            break;
                        }
                    }
                }

                stockList.Remove(maxKey);
                stockList.Add(ordersList[i]);
                total++;

            }

        }

        Console.WriteLine("{0}", total);

        return;

    }
}
