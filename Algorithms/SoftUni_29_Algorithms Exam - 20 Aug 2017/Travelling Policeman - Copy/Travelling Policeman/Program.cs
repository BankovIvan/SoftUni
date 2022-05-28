#define JUDGE

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        int i = 0;
        string[] s = {"START"};
        int knapsackCapacity = int.Parse(Console.ReadLine());
        List<KnapsackItem> knapsackItems = new List<KnapsackItem>();

        s = Console.ReadLine().Split(',');

        int damage, pokemons;

        while (s[0] != "End")
        {
            damage = int.Parse(s[1].Trim());
            pokemons = int.Parse(s[2].Trim());

            if ((pokemons * 10 - damage) > 0)
            {
                knapsackItems.Add(new KnapsackItem(s[0].Trim(), damage, pokemons, int.Parse(s[3].Trim()), i));
            }

            i++;

            s = Console.ReadLine().Split(',');

        }



        int[,] maxValues = new int[knapsackItems.Count + 1, knapsackCapacity + 1];
        bool[,] itemIncluded = new bool[knapsackItems.Count + 1, knapsackCapacity + 1];

        List<KnapsackItem> itemsTaken = FillKnapsack(knapsackItems, knapsackCapacity, maxValues, itemIncluded);

        //itemsTaken.Reverse();
        //itemsTaken = itemsTaken.OrderByDescending(x => x.price).ToList();

        itemsTaken = itemsTaken.OrderBy(x => x.myId).ToList();

        if(itemsTaken.Count > 1)
        {
            Console.WriteLine(string.Join(" -> ", itemsTaken.Select(x => x.name)));
        }
        else if(itemsTaken.Count == 1)
        {
            Console.WriteLine(itemsTaken.First().name);
        }
        else
        {
            Console.WriteLine();
        }
        Console.WriteLine("Total pokemons caught -> {0}", itemsTaken.Select(x => x.pokemons).Sum());
        Console.WriteLine("Total car damage -> {0}", itemsTaken.Select(x => x.damage).Sum());
        Console.WriteLine("Fuel Left -> {0}", knapsackCapacity - itemsTaken.Select(x => x.fuel).Sum());

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
                if (knapsackItems[i].fuel > currCapacity) continue;

                valueIncluded = knapsackItems[i].price + maxValues[i, currCapacity - knapsackItems[i].fuel];
                if (valueIncluded > maxValues[i, currCapacity])
                {
                    maxValues[i + 1, currCapacity] = valueIncluded;
                    itemIncluded[i + 1, currCapacity] = true;
                }
                else
                {
                    maxValues[i + 1, currCapacity] = maxValues[i, currCapacity];
                }

            }

        }

        PrintMatrix(maxValues, 5, true);
        PrintMatrix(itemIncluded, 5, true);

        //Reconstruct solution;
        capacity = knapsackCapacity;

        for (i = knapsackItems.Count; i > 0; i--)
        {
            if (!itemIncluded[i, capacity]) continue;

            itemsTaken.Add(knapsackItems[i - 1]);
            capacity -= knapsackItems[i - 1].fuel;

        }

        return itemsTaken;

    }

    public static void PrintMatrix(int[,] matrix, int padding = 5, bool addNewLine = false)
    {
        string s;

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            s = matrix[i, 0].ToString().PadLeft(padding);
            for (int j = 1; j < matrix.GetLength(1); j++)
            {
                s = s + "," + matrix[i, j].ToString().PadLeft(padding);
            }
            Console.WriteLine(s);
        }

        if (addNewLine) Console.WriteLine();

    }

    public static void PrintMatrix(bool[,] matrix, int padding = 5, bool addNewLine = false)
    {
        string s;

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            s = matrix[i, 0].ToString().PadLeft(padding);
            for (int j = 1; j < matrix.GetLength(1); j++)
            {
                s = s + "," + matrix[i, j].ToString().PadLeft(padding);
            }
            Console.WriteLine(s);
        }

        if (addNewLine) Console.WriteLine();

    }

}

public class KnapsackItem : IComparable<KnapsackItem>
{

    public int fuel { get; set; }
    public int pokemons { get; set; }
    public int damage { get; set; }
    public int price { get; set; }
    public string name { get; set; }
    public int myId { get; set; }

    public KnapsackItem()
    {
    }

    public KnapsackItem(string name, int damage, int pokemons, int fuel, int myId)
    {
        this.fuel = fuel;
        this.pokemons = pokemons;
        this.damage = damage;
        this.price = pokemons * 10 - damage;
        this.name = name;
        this.myId = myId;
    }

    public int CompareTo(KnapsackItem other)
    {
        return other.price.CompareTo(this.price);
    }

    public override string ToString()
    {
        return "<" + this.name + "," + this.fuel.ToString() + ":" + this.price.ToString() + ">";
    }
}

