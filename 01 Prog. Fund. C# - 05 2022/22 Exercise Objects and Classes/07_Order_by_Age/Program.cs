using System;
using System.Collections.Generic;
using System.Numerics;

namespace _07_Order_by_Age
{
    class Program
    {
        class Person{
            public string Name {get; set;}
            public string ID {get; set;}
            public int Age {get; set;}

            public Person(string Name, string ID, int Age){
                this.Name = Name;
                this.ID = ID;
                this.Age = Age;
            }
        }

        static void Main(string[] args)
        {
            List<Person> lstPersons = new List<Person>();
            string[] arrInput;
            int index = 0;

            while(true){
                arrInput = Console.ReadLine().Split(' ');
                if(arrInput[0] == "End"){
                    break;
                }

                index = lstPersons.FindIndex(x => x.ID == arrInput[1]);
                if(index >= 0){
                    lstPersons[index].Name = arrInput[0];
                    lstPersons[index].Age = int.Parse(arrInput[2]);
                }else{
                    lstPersons.Add(new Person(arrInput[0], arrInput[1], int.Parse(arrInput[2])));
                }

            }

            lstPersons.Sort((x,y) => x.Age.CompareTo(y.Age));
            lstPersons.ForEach(x => {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("{0} with ID: {1} is {2} years old.", x.Name, x.ID, x.Age);           
                Console.ResetColor();
            });

        }
    }
}