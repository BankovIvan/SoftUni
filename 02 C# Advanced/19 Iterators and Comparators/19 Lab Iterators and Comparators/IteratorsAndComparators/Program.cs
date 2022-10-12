namespace IteratorsAndComparators
{
    using System;

    internal class Program
    {
        static void Main(string[] args)
        {
            Book bookOne = new Book("Animal Farm", 2003, "George Orwell");
            Book bookTwo = new Book("The Documents in the Case", 2002, "Dorothy Sayers", "Robert Eustace");
            Book bookThree = new Book("The Documents in the Case", 1930);

            Library library = new Library(bookOne, bookTwo, bookThree);

            library.Books.Sort(new BookComparator());

            foreach (var book in library)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(book);
                Console.ResetColor();
            }

        }
    }
}
