using System;
using ValidationAttributes.Models;

namespace ValidationAttributes
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var person = new Person
             (
                 null,
                 -1
             );

            /*
            var Go6ko = new Person
             (
                 "Go6ko",
                 20
             );
            */

            bool isValidEntity = Validator.IsValid(person);
            //bool isValidGo6ko = Validator.IsValid(Go6ko);

            Console.WriteLine(isValidEntity);
            //Console.WriteLine(isValidGo6ko);
        }
    }
}
