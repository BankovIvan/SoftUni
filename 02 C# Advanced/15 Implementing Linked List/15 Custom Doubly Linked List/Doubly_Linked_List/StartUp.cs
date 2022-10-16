namespace CustomDoublyLinkedList
{
    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {
            DoublyLinkedList lstDoubly = new DoublyLinkedList();

            lstDoubly.AddFirst(3);
            lstDoubly.AddFirst(2);
            lstDoubly.AddFirst(1);
            lstDoubly.AddLast(98);
            lstDoubly.AddLast(99);
            lstDoubly.AddLast(100);

            Console.WriteLine("COUNT == {0}", lstDoubly.Count);
            Console.WriteLine(String.Join(", ", lstDoubly.ToArray()));

            lstDoubly.ForEach(x => Console.WriteLine(x));

            lstDoubly.RemoveLast();
            lstDoubly.RemoveFirst();

            Console.WriteLine("COUNT == {0}", lstDoubly.Count);
            Console.WriteLine(String.Join(", ", lstDoubly.ToArray()));

            lstDoubly.RemoveLast();
            lstDoubly.RemoveFirst();

            Console.WriteLine("COUNT == {0}", lstDoubly.Count);
            Console.WriteLine(String.Join(", ", lstDoubly.ToArray()));

            lstDoubly.RemoveLast();
            lstDoubly.RemoveFirst();

            Console.WriteLine("COUNT == {0}", lstDoubly.Count);
            Console.WriteLine(String.Join(", ", lstDoubly.ToArray()));

            lstDoubly.AddFirst(3);
            lstDoubly.AddFirst(2);
            lstDoubly.AddFirst(1);
            lstDoubly.AddLast(98);
            lstDoubly.AddLast(99);
            lstDoubly.AddLast(100);

            Console.ForegroundColor = ConsoleColor.Green;
            lstDoubly.ForEach(x => Console.WriteLine(x));
            Console.ResetColor();


        }
    }
}
