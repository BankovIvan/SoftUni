namespace PersonsInfo
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;
    using System.Linq;
    using System.Text;
	//using System.Text.RegularExpressions;


    public class StartUp 
    {
        static void Main(string[] args)
        {

            var lines = int.Parse(Console.ReadLine());
            var persons = new List<Person>();
            for (int i = 0; i < lines; i++)
            {
                var cmdArgs = Console.ReadLine().Split();
                var person = new Person(cmdArgs[0], cmdArgs[1], int.Parse(cmdArgs[2]));
                persons.Add(person);
            }
            
            Console.ForegroundColor = ConsoleColor.Yellow;

            persons.OrderBy(p => p.FirstName)
                .ThenBy(p => p.Age)
                .ToList()
                .ForEach(p => Console.WriteLine(p.ToString()));
      
            Console.ResetColor();

        }
    }
}