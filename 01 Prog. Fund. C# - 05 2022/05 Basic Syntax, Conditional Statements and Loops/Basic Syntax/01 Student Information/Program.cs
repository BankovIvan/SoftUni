using System;

namespace _01_Student_Information
{
    class Program
    {
        static void Main(string[] args)
        {

            string sName;
            int nAge;
            float fGrade;

            sName = Console.ReadLine();
            nAge = int.Parse(Console.ReadLine());
            fGrade = float.Parse(Console.ReadLine());

            Console.WriteLine("Name: {0}, Age: {1}, Grade: {2:F2}", sName, nAge, fGrade);

        }
    }
}
