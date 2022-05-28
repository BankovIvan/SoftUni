#define JUDGE

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static void Main(string[] args)
    {

        /*
        KnapsackItem[] knapsackItems = new KnapsackItem[]
        {
            new KnapsackItem {name = "Item1", weight = 5, price = 30},
            new KnapsackItem {name = "Item2", weight = 8, price = 120},
            new KnapsackItem {name = "Item3", weight = 7, price = 10},
            new KnapsackItem {name = "Item4", weight = 0, price = 20},
            new KnapsackItem {name = "Item5", weight = 4, price = 50},
            new KnapsackItem {name = "Item6", weight = 5, price = 80},
            new KnapsackItem {name = "Item7", weight = 2, price = 10}
        };
        int knapsackCapacity = 20;
        */
        /*
        KnapsackItem[] knapsackItems = new KnapsackItem[]
{
            new KnapsackItem {name = "Flashlight", weight = 2, price = 3},
            new KnapsackItem {name = "Laptop", weight = 2, price = 1},
            new KnapsackItem {name = "Book", weight = 1, price = 3}
};
        int knapsackCapacity = 4;
        */

        string s = "start";
        int knapsackCapacity = int.Parse(Console.ReadLine());
        List<KnapsackItem> knapsackItems = new List<KnapsackItem>();

        while(s != "")
        {
            s = Console.ReadLine();
            if(s.ToUpper() != "END")
            {
                //s = s.Split()[0];
                knapsackItems.Add(new KnapsackItem(int.Parse(s.Split()[1]), int.Parse(s.Split()[2]), s.Split()[0]));
            }
            else
            {
                break;
            }

        }



        int[,] maxValues = new int[knapsackItems.Count + 1, knapsackCapacity + 1];
        bool[,] itemIncluded = new bool[knapsackItems.Count + 1, knapsackCapacity + 1];

        List<KnapsackItem> itemsTaken = FillKnapsack(knapsackItems, knapsackCapacity, maxValues, itemIncluded);

        Console.WriteLine("Total Weight: {0}", itemsTaken.Select(x => x.weight).Sum());
        Console.WriteLine("Total Value: {0}", itemsTaken.Select(x => x.price).Sum());
        Console.WriteLine(string.Join("\n", itemsTaken.OrderBy(x => x.name).Select(x => x.name))); // itemsTaken.Select(x => x.name).Reverse()));

        return;

    }

    private static List<KnapsackItem> FillKnapsack(List<KnapsackItem> knapsackItems, int knapsackCapacity, int[,] maxValues, bool[,] itemIncluded)
    {
        int i, capacity, currCapacity, valueIncluded;
        List<KnapsackItem> itemsTaken = new List<KnapsackItem>();

        //Calculate memo matrix;
        for (i = 0; i < knapsackItems.Count; i++)
        {
            //NOTE: i = currCapacity + 1 !!!
            for (currCapacity = 1; currCapacity <= knapsackCapacity; currCapacity++)
            {
                if (knapsackItems[i].weight > currCapacity) continue;

                valueIncluded = knapsackItems[i].price + maxValues[i, currCapacity - knapsackItems[i].weight];
                if(valueIncluded > maxValues[i, currCapacity])
                {
                    maxValues[i + 1, currCapacity] = valueIncluded;
                    itemIncluded[i + 1, currCapacity] = true;
                }
                else
                {
                    maxValues[i + 1, currCapacity] = maxValues[i, currCapacity];
                }

#if !JUDGE
                MyConsolePrintHelper.PrintMatrix(maxValues, 5, true);
                MyConsolePrintHelper.PrintMatrix(itemIncluded, 5, true);

#endif

            }

        }


        //Reconstruct solution;
        capacity = knapsackCapacity;

        for (i = knapsackItems.Count; i > 0; i--)
        {
            if (!itemIncluded[i, capacity]) continue;

            itemsTaken.Add(knapsackItems[i - 1]);
            capacity -= knapsackItems[i - 1].weight;

        }


        return itemsTaken;

    }

}

public class KnapsackItem : IComparable<KnapsackItem>
{

    public int weight { get; set; }
    public int price { get; set; }
    public string name { get; set; }

    public KnapsackItem()
    {
    }

    public KnapsackItem(int weight, int price, string name)
    {
        this.weight = weight;
        this.price = price;
        this.name = name;
    }

    public int CompareTo(KnapsackItem other)
    {
        return other.price.CompareTo(this.price);
    }

    public override string ToString()
    {
        return this.name + "," + this.weight.ToString() + "," + this.price.ToString();
    }
}

