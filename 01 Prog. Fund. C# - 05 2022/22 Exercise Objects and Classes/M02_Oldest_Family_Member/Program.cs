using System;
using System.Collections.Generic;
using System.Numerics;

namespace _M02_Oldest_Family_Member
{
    class Person{
        public string Name {get; set;}
        public int Age {get; set;}

        public override string ToString()
        {
            return string.Format("{0} {1}", this.Name, this.Age);
        }
    }

    class Family{
        public List<Person> Members {get; set;}

        public Family(){
            Members = new List<Person>();
        }

        public void AddMember(Person member){
            Members.Add(member);
        }

        public Person GetOldestMember(){
            Person OldestPerson = null;
            
            if(Members.Count >= 0){
                OldestPerson = Members[0];

                Members.ForEach(x => {
                    if(OldestPerson.Age < x.Age){
                        OldestPerson = x;
                    }
                });
            
            }

            return OldestPerson;
        }

    }


    class Program
    {
        static void Main(string[] args)
        {
            Family objFamily = new Family();
            int i, nRepeat;
            string[] arrInput;

            nRepeat = int.Parse(Console.ReadLine());
            for(i = 0; i < nRepeat; i++){
                arrInput = Console.ReadLine().Split(' ');
                objFamily.AddMember(new Person(){Name = arrInput[0], Age = int.Parse(arrInput[1])});
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(objFamily.GetOldestMember());           
            Console.ResetColor();

        }
    }
}