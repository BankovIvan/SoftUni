using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static void Main(string[] args)
    {

        int fuel;
        List<street> city = new List<street>();
        List<street> itemsTaken = new List<street>();

        fuel = ReadData(city);

        itemsTaken = FillKnapsack(city, fuel);
        itemsTaken.Reverse();

        Console.WriteLine(string.Join(" -> ", itemsTaken.Select(x => x.name).ToArray()));

        Console.WriteLine("Total pokemons caught -> {0}", itemsTaken.Select(x => x.pokemons).ToArray().Sum());
        Console.WriteLine("Total car damage -> {0}", itemsTaken.Select(x => x.damage).ToArray().Sum());
        Console.WriteLine("Fuel Left -> {0}", fuel - itemsTaken.Select(x => x.length).ToArray().Sum());

        return;

    }


    private static List<street> FillKnapsack(List<street> city, int fuel)
    {
        int i, capacity, currCapacity, valueIncluded;
        int[,] maxValues = new int[city.Count + 1, fuel + 1];
        bool[,] itemIncluded = new bool[city.Count + 1, fuel + 1];
        List<street> itemsTaken = new List<street>();

        //Calculate memo matrix;
        for (i = 0; i < city.Count; i++)
        {
            //NOTE: i = currCapacity + 1 !!!
            for (currCapacity = 1; currCapacity <= fuel; currCapacity++)
            {
                if (city[i].length > currCapacity) continue;

                valueIncluded = city[i].price + maxValues[i, currCapacity - city[i].length];
                if (valueIncluded > maxValues[i, currCapacity])
                {
                    maxValues[i + 1, currCapacity] = valueIncluded;
                    itemIncluded[i + 1, currCapacity] = true;
                }
                else
                {
                    maxValues[i + 1, currCapacity] = maxValues[i, currCapacity];
                }

                //PrintMatrix(maxValues, 5, true);
                //PrintMatrix(itemIncluded, 5, true);

            }

        }


        //Reconstruct solution;
        capacity = fuel;

        for (i = city.Count; i > 0; i--)
        {
            if (!itemIncluded[i, capacity]) continue;

            itemsTaken.Add(city[i - 1]);
            capacity -= city[i - 1].length;

        }

        return itemsTaken;

    }

    private static int ReadData(List<street> city)
    {
        string[] s;
        street nextStreet;
        int fuel;

        fuel = int.Parse(Console.ReadLine());

        s = Console.ReadLine().Split(',').ToArray();
        while (s.Length == 4)
        {
            nextStreet = new street(s[0], int.Parse(s[1]), int.Parse(s[2]), int.Parse(s[3]));
            if (nextStreet.price >= 0 && nextStreet.length <= fuel)
            {
                city.Add(nextStreet);
            }

            s = Console.ReadLine().Split(',').ToArray();
        }

        return fuel;
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

public class street : IComparable<street>
{
    public string name;
    public int damage;
    public int pokemons;
    public int length;
    public int price;
    public bool check;

    public street(string name, int damage, int pokemons, int length)
    {
        this.name = name;
        this.damage = damage;
        this.pokemons = pokemons;
        this.length = length;
        this.price = pokemons * 10 - damage;
        this.check = false;
    }

    public int CompareTo(street other)
    {

        return other.price.CompareTo(this.price);
    }

    public override string ToString()
    {
        return "<" + this.name + ":" + this.damage.ToString().PadLeft(3) + "," + this.pokemons.ToString().PadLeft(3) + "," + this.length.ToString().PadLeft(3) + ":" + this.price.ToString().PadLeft(3) + ">";
    }
}
