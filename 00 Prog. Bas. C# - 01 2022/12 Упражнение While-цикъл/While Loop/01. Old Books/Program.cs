using System;

namespace _01._Old_Books
{
    class Program
    {
        static void Main(string[] args)
        {

            string sBookIn = "", sBookName = "";
            int nBooksCount = 0;

            sBookName = Console.ReadLine();
            sBookIn = Console.ReadLine();

            while (sBookIn != "No More Books")
            {
                if(sBookName == sBookIn)
                {
                    Console.WriteLine("You checked {0} books and found it.", nBooksCount);
                    return;
                }

                nBooksCount++;
                sBookIn = Console.ReadLine();
            }

            Console.WriteLine("The book you search is not here!");
            Console.WriteLine("You checked {0} books.", nBooksCount);

        }
    }
}
