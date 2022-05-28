using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        double totalCpacity;
        int itemsData, i;
        double total = 0.0;
        string s;

        List<KnapsackItem> givenItems = new List<KnapsackItem>();
        //Dictionary<int, int> selectedItems = new Dictionary<int, int>();

        totalCpacity = double.Parse(Console.ReadLine().Split(' ').Last());
        itemsData = int.Parse(Console.ReadLine().Split(' ').Last());

        for (i = 0; i < itemsData; i++)
        {
            s = Console.ReadLine();
            givenItems.Add(new KnapsackItem(double.Parse(s.Split(' ').First()), double.Parse(s.Split(' ').Last())));
        }

        Knapsack(givenItems, totalCpacity);

        for (i = 0; i < givenItems.Count; i++)
        {
            if(givenItems[i].percentsTaken > 0)
            {
                s = (givenItems[i].percentsTaken == 100.0) ? givenItems[i].percentsTaken.ToString("F0") : givenItems[i].percentsTaken.ToString("F2");
                Console.WriteLine("Take {0}% of item with price {1:F2} and weight {2:F2}",
                                        //Math.Round(givenItems[i].percentsTaken, 2), 
                                        //givenItems[i].percentsTaken / 100,
                                        s,
                                        givenItems[i].price, 
                                        givenItems[i].weight);

                total += givenItems[i].price * givenItems[i].percentsTaken / 100;
            }

        }

        Console.WriteLine("Total price: {0:F2}", total);
        return;
    }

    private static void Knapsack(List<KnapsackItem> givenItems, double totalCpacity)
    {
        int i = 0;
        double addedWeight = 0.0;

        givenItems.Sort();

        while(addedWeight <= totalCpacity && i < givenItems.Count)
        {
            //double itemCapacity = givenItems[i].value * givenItems[i].percentsAvailable / 100.0;

            if(givenItems[i].weight + addedWeight <= totalCpacity)
            {
                givenItems[i].percentsTaken = 100.0;
                addedWeight += givenItems[i].weight;
                //givenItems.RemoveAt(i);
                //i++;
            }
            //else if(givenItems[i].weight > 0 && givenItems[i].weight < totalCpacity - addedWeight)
            else if (givenItems[i].weight > 0)
            {
                givenItems[i].percentsTaken = (totalCpacity - addedWeight) * 100 / givenItems[i].weight;
                addedWeight += givenItems[i].weight * givenItems[i].percentsTaken / 100;
                break;
            }

            i++;

        }

    }

    class KnapsackItem : IComparable<KnapsackItem>
    {

        public double price;
        public double weight;
        public double value;
        public double percentsTaken;

        public KnapsackItem(double price, double weight)
        {
            this.price = price;
            this.weight = weight;
            this.value = this.price / this.weight;
            percentsTaken = 0.0;
        }

        public int CompareTo(KnapsackItem other)
        {
            return other.value.CompareTo(this.value);
        }

        public override string ToString()
        {
            return this.value.ToString();
        }

    }
}
