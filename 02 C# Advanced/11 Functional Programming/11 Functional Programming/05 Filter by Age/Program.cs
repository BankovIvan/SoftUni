namespace _05_Filter_by_Age
{

    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public Person(int Id, string Name, int Age)
        {
            this.Id = Id;
            this.Name = Name;
            this.Age = Age;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = ReadPeople();

            string condition = Console.ReadLine();
            int ageThreshold = int.Parse(Console.ReadLine());  
            Func<Person, bool> filter = CreateFilter(condition, ageThreshold);

            string format = Console.ReadLine();
            Action<Person> printer = CreatePrinter(format);

            PrintFilteredPeople(people, filter, printer);

        }

        private static List<Person> ReadPeople()
        {
            int nRepeat = int.Parse(Console.ReadLine());
            List<Person> ret = new List<Person>();
            

            for(int i = 0; i < nRepeat; i++)
            {
                string[] arrInput = Console.ReadLine().Split(", ");
                ret.Add(new Person(i, arrInput[0], int.Parse(arrInput[1])));
            }

            return ret;

        }

        public static Func<Person, bool> CreateFilter(string condition, int ageThreshold)
        {
            switch (condition)
            {
                case "younger": return x => x.Age < ageThreshold;
                case "older": return x => x.Age >= ageThreshold;
                default: throw new ArgumentException(condition);
            }
        }

        public static Action<Person> CreatePrinter(string format)
        {
            switch (format)
            {
                case "name":
                    return person => Console.WriteLine($"{person.Name}");
                case "age":
                    return person => Console.WriteLine($"{person.Age}");
                case "name age":
                    return person => Console.WriteLine($"{person.Name} - {person.Age}");
                default: throw new ArgumentException(format);
            }

        }

        public static void PrintFilteredPeople(
                                List<Person> people, 
                                Func<Person, bool> filter, 
                                Action<Person> printer)
        {
            people.Where(filter).ToList().ForEach(x => printer(x));
        }

    }
}