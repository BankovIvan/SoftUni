namespace P03_SalesDatabase
{
    using P03_SalesDatabase.Data;

    internal class StartUp
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            var context = new SalesContext();
        }
    }
}