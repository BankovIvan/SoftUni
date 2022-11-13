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
                    try{
                        var cmdArgs = Console.ReadLine().Split();
                        var person = new Person(cmdArgs[0], 
                                                cmdArgs[1],
                                                int.Parse(cmdArgs[2]), 
                                                decimal.Parse(cmdArgs[3]));

                        persons.Add(person);
                    } catch (Exception e){
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(e.Message);
                        Console.ResetColor();
                    }
                }

            Console.ForegroundColor = ConsoleColor.Yellow;

            //persons.ForEach(p => Console.WriteLine(p.ToString()));

            Team team = new Team("SoftUni");

            foreach (Person person in persons)
            {
                team.AddPlayer(person);
            }

            Console.ForegroundColor = ConsoleColor.Blue;

            //Console.WriteLine("First team has {0} players.", team.FirstTeam.Count);
            //Console.WriteLine("Reserve team has {0} players.", team.ReserveTeam.Count);
            Console.WriteLine(team.ToString());

            Console.ResetColor();

        }
    }
}