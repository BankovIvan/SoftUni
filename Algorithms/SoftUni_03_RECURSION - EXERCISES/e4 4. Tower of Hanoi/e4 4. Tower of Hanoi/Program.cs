using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    private static int steps = 0;

    private static Stack<int> source = new Stack<int>();
    private static Stack<int> spare = new Stack<int>();
    private static Stack<int> destination = new Stack<int>();

    static void Main(string[] args)
    {


        int n = int.Parse(Console.ReadLine());

        if (n < 1) return;

        for (int i = n; i > 0; i--)
        {
            source.Push(i);
        }

        PrintRods();

        TowerOfHanoi(source.Count, source, destination, spare);

        return;
    }

    private static void PrintRods()
    {
        Console.WriteLine("Source: {0}", string.Join(", ", source.Reverse()));
        Console.WriteLine("Destination: {0}", string.Join(", ", destination.Reverse()));
        Console.WriteLine("Spare: {0}", string.Join(", ", spare.Reverse()));
        Console.WriteLine();

    }

    private static void TowerOfHanoi(int count, Stack<int> source, Stack<int> destination, Stack<int> spare)
    {
        if(count > 1)
        {
            TowerOfHanoi(count - 1, source, spare, destination);
            destination.Push(source.Pop());

            steps++;
            //Console.WriteLine("Step #{0}: Moved Disk {1}", steps, count);
            Console.WriteLine("Step #{0}: Moved disk", steps);
            PrintRods();




            TowerOfHanoi(count - 1, spare, destination, source);


        }
        else
        {

            destination.Push(source.Pop());

            steps++;
            //Console.WriteLine("Step #{0}: Moved Disk {1}", steps, count);
            Console.WriteLine("Step #{0}: Moved disk", steps);
            PrintRods();
        }
    }
}
