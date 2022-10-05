namespace DefiningClasses
{

    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {

            ///////////////////////////
            ///
            /// 5. *Date Modifier
            ///
            /////////////////////////////

            string sDate1 = Console.ReadLine();
            string sDate2 = Console.ReadLine();

            DateModifier dateDiff = new DateModifier(sDate1, sDate2);

            Console.WriteLine(dateDiff.DateDiff);

            return;

            ///////////////////////////
            ///
            /// 4. Opinion Poll
            ///
            /////////////////////////////

            Family objFamily = new Family();

            int nRepeat = int.Parse(Console.ReadLine());
            for(int i = 0; i < nRepeat; i++)
            {
                string[] arrInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                objFamily.AddMember(new Person(arrInput[0], int.Parse(arrInput[1])));

            }

            foreach(var v in objFamily.People.Where(x => x.Age > 30).OrderBy(x => x.Name))
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("{0} - {1}", v.Name, v.Age);
                Console.ResetColor();

            }

        }
    }
}
