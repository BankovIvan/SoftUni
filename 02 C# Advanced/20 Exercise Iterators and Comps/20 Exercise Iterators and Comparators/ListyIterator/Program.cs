namespace ListyIterator
{
    using System;
    using System.Collections.Generic;
    //using System.Linq;

    internal class Program
    {
        static void Main(string[] args)
        { 
            
            Func<int,int,int> StrangeCompare = (x,y) => 
            {
                int ret = -1;
                bool xEven = (x & 1) == 1;
                bool yEven = (y & 1) == 1;

                if(xEven && yEven)
                {
                    ret = x.CompareTo(y);
                }
                else if(xEven && !yEven)
                {
                    ret = 1;
                }
                else if(!xEven && yEven)
                {
                    ret = -1;
                }
                else
                {
                    ret = x.CompareTo(y); ;
                }
                    
                return ret; 
            };
            

            int[] arrInput = Array.ConvertAll(
                Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries),
                new Converter<string, int>(int.Parse));

            Array.Sort(arrInput, new StrangeCompare());

            Array.Sort(arrInput, (x, y) => StrangeCompare(x, y));

            Console.WriteLine(String.Join(' ', arrInput));

        }

        static void _6_Main(string[] args)
        {
            HashSet<Person> hashsetPersons = new HashSet<Person>();
            SortedSet<Person> sortedsetPersons = new SortedSet<Person>();
            int nRepeat = int.Parse(Console.ReadLine());

            for(int i = 0; i < nRepeat; i++)
            {
                string[] arrInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                Person person = new Person(arrInput[0], int.Parse(arrInput[1]), "1");

                hashsetPersons.Add(person);
                sortedsetPersons.Add(person);

            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(sortedsetPersons.Count);
            //foreach(var v in sortedsetPersons)
            //{
            //   Console.WriteLine("{0}-{1}", v.Name, v.Age);
            //}

            Console.WriteLine(hashsetPersons.Count);
            //foreach (var v in hashsetPersons)
            //{
            //    Console.WriteLine("{0}-{1}", v.Name, v.Age);
            //}
            Console.ResetColor();

        }

        static void _5_Main(string[] args)
        {

            List<Person> lstPersons = new List<Person>();
            string[] arrInput;

            while ((arrInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries))[0] != "END")
            {
                lstPersons.Add(new Person(arrInput[0], int.Parse(arrInput[1]), arrInput[2]));
            }

            int element = int.Parse(Console.ReadLine()) - 1;
            int matches = lstPersons.FindAll(x => x.CompareTo(lstPersons[element]) == 0).Count;

            Console.ForegroundColor = ConsoleColor.Green;
            if(matches > 1)
            {
                Console.WriteLine("{0} {1} {2}", matches, lstPersons.Count - matches, lstPersons.Count);
            }
            else
            {
                Console.WriteLine("No matches");
            }
            Console.ResetColor();


        }

        static void _4_Main(string[] args)
        {

            Lake<int> frogs = new Lake<int>(
                Array.ConvertAll(
                    Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries),
                    new Converter<string, int>(int.Parse)));

            Console.WriteLine(String.Join(", ", frogs));

        }

        static void _3_Main(string[] args)
        {
            Stack<int> elements = new Stack<int>();

            while (true)
            {
                string[] sCommand = Console
                                        .ReadLine()
                                        .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

                if (sCommand[0] == "END")
                {
                    break;
                }
                else if (sCommand[0] == "Push")
                {
                    int[] ints = new int[sCommand.Length - 1];
                    for(int i = 1; i < sCommand.Length; i++)
                    {
                        ints[i - 1] = int.Parse(sCommand[i]);
                    }
                    elements.Push(ints);
                }
                else if (sCommand[0] == "Pop")
                {
                    try
                    {
                        //Console.ForegroundColor = ConsoleColor.Green;
                        //Console.WriteLine(elements.Pop());
                        //Console.ResetColor();
                        elements.Pop();
                    }
                    catch (Exception exception)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(exception.Message);
                        Console.ResetColor();
                    }

                }
            }

            foreach(var v in elements)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(v.ToString());
                Console.ResetColor();
            }

            foreach (var v in elements)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(v.ToString());
                Console.ResetColor();
            }

        }

        static void _1_2_Main(string[] args)
        {
            ListyIterator<string> elements = new ListyIterator<string>(
                Console.ReadLine().Split(new string[] { "Create", " " }, StringSplitOptions.RemoveEmptyEntries));

            string sCommand;
            while ((sCommand = Console.ReadLine()) != "END")
            {
                if(sCommand == "Move")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(elements.Move());
                    Console.ResetColor();
                }
                else if (sCommand == "Print")
                {
                    try
                    {
                        elements.Print();
                    }
                    catch (Exception exception)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(exception.Message);
                        Console.ResetColor();
                    }
                   
                }
                else if (sCommand == "HasNext")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(elements.HasNext());
                    Console.ResetColor();
                }
                else if (sCommand == "PrintAll")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    foreach(var v in elements)
                    {
                        Console.Write("{0} ", v.ToString());
                    }
                    Console.ResetColor();
                    Console.WriteLine();
                }
            }

        }
    }
}
