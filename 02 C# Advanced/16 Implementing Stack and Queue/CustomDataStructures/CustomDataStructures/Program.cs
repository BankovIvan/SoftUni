namespace CustomDataStructures
{
    using System;
    using System.Collections.Generic;

    internal class Program
    {
        static void Main(string[] args)
        {
            TestCustomList();
            TestCustomStack();
            TestCustomQueue();


        }

        private static void TestCustomQueue()
        {
            CustomQueue customQueue = new CustomQueue();

            customQueue.Enqueue(1);
            customQueue.Enqueue(2);

            Console.WriteLine(customQueue);

            customQueue.Enqueue(3);
            customQueue.Enqueue(4);

            Console.WriteLine(customQueue);

            customQueue.Enqueue(5);
            customQueue.Enqueue(6);
            customQueue.Enqueue(7);
            customQueue.Enqueue(8);
            customQueue.Enqueue(9);
            customQueue.Enqueue(10);

            Console.WriteLine(customQueue);

            Console.WriteLine();
            Console.WriteLine(customQueue.Dequeue());
            Console.WriteLine(customQueue.Dequeue());

            Console.WriteLine(customQueue);

            Console.WriteLine();
            Console.WriteLine(customQueue.Dequeue());
            Console.WriteLine(customQueue.Dequeue());
            Console.WriteLine(customQueue.Dequeue());
            Console.WriteLine(customQueue.Dequeue());

            Console.WriteLine(customQueue);
            Console.WriteLine();

            Console.WriteLine(customQueue.Peek());
            Console.WriteLine();

            customQueue.ForEach(x => Console.WriteLine(x));
            Console.WriteLine();

            customQueue.Clear();

            Console.WriteLine(customQueue);


        }

        private static void TestCustomStack()
        {
            CustomStack customStack = new CustomStack();

            customStack.Push(1);
            customStack.Push(2);

            Console.WriteLine(customStack);

            customStack.Push(3);
            customStack.Push(4);

            Console.WriteLine(customStack);

            customStack.Push(5);
            customStack.Push(6);

            Console.WriteLine(customStack);

            Console.WriteLine();
            Console.WriteLine(customStack.Peek());
            Console.WriteLine(customStack.Pop());
            Console.WriteLine(customStack.Peek());
            Console.WriteLine(customStack.Pop());
            Console.WriteLine();

            Console.WriteLine(customStack);

            Console.WriteLine();
            Console.WriteLine(customStack.Peek());
            Console.WriteLine(customStack.Pop());
            Console.WriteLine(customStack.Peek());
            Console.WriteLine(customStack.Pop());
            Console.WriteLine();

            Console.WriteLine(customStack);


            Console.WriteLine();
            Console.WriteLine(customStack.Peek());
            Console.WriteLine(customStack.Pop());
            Console.WriteLine(customStack.Peek());
            Console.WriteLine(customStack.Pop());
            Console.WriteLine();

            Console.WriteLine(customStack);

            customStack.Push(-1);
            customStack.Push(-2);
            customStack.Push(-3);
            customStack.Push(-4);
            customStack.Push(-5);
            customStack.Push(-6);
            customStack.Push(-7);
            customStack.Push(-8);
            customStack.Push(-9);
            customStack.Push(-10);

            Console.WriteLine(customStack);

            Console.WriteLine();
            customStack.ForEach(x => Console.WriteLine(x));

            Console.WriteLine();
            for(int i = 0; i < customStack.Count; i++)
            {
                Console.WriteLine(customStack[i]);
            }

        }

        private static void TestCustomList()
        {
            CustomList lstTest = new CustomList();

            lstTest.Add(1);
            lstTest.Add(2);
            lstTest.Add(3);
            lstTest.Add(4);
            lstTest.Add(5);
            lstTest.Add(6);
            lstTest.Add(7);
            lstTest.Add(8);
            lstTest.Add(9);
            lstTest.Add(10);

            Console.WriteLine(lstTest);

            //Console.WriteLine("\n RemoveAt Index = ");
            //int nRemove = int.Parse(Console.ReadLine());
            //Console.WriteLine(lstTest.RemoveAt(nRemove));

            lstTest.RemoveAt(0);
            lstTest.RemoveAt(0);
            lstTest.RemoveAt(0);
            lstTest.RemoveAt(0);
            lstTest.RemoveAt(0);
            lstTest.RemoveAt(0);

            Console.WriteLine(lstTest);

            lstTest.RemoveAt(0);
            lstTest.RemoveAt(0);
            lstTest.RemoveAt(0);

            Console.WriteLine(lstTest);

            lstTest.RemoveAt(0);

            lstTest.Insert(0, 8);
            lstTest.Insert(0, 7);
            lstTest.Insert(0, 6);
            lstTest.Insert(0, 5);
            lstTest.Insert(0, 4);
            lstTest.Insert(0, 3);
            lstTest.Insert(0, 2);
            lstTest.Insert(0, 1);
            lstTest.Insert(0, 0);

            Console.WriteLine(lstTest);

            lstTest.Insert(0, -1);
            lstTest.Insert(0, -2);
            lstTest.Insert(0, -3);
            lstTest.Insert(0, -4);
            lstTest.Insert(0, -5);
            lstTest.Insert(0, -6);

            Console.WriteLine(lstTest);

            lstTest.Insert(15, 9);

            Console.WriteLine(lstTest);

            Console.WriteLine();
            Console.WriteLine(lstTest.Contains(-100));
            Console.WriteLine();

            lstTest.Swap(0, 15);
            lstTest.Swap(1, 14);

            Console.WriteLine(lstTest);

            Console.WriteLine();
            Console.WriteLine(lstTest.Find(-1));
            Console.WriteLine();

            lstTest.Swap(0, 15);
            lstTest.Swap(1, 14);
            lstTest.Reverse();

            for (int i = 0; i < lstTest.Count; i++)
            {
                Console.WriteLine(lstTest[i]);
            }
        }
    }
}
