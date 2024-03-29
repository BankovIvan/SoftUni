﻿namespace CustomDoublyLinkedList
{
    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {
            CustomDoublyLinkedList<int> lstDoubly = new CustomDoublyLinkedList<int>();

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

        }
    }
}
