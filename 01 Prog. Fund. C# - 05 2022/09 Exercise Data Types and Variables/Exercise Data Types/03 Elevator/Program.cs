using System;

namespace _03_Elevator
{
    class Program
    {
        static void Main(string[] args)
        {
            int nPeople, nCapacity, nCourses;

            nPeople = int.Parse(Console.ReadLine());
            nCapacity = int.Parse(Console.ReadLine());

            nCourses = nPeople / nCapacity;

            if ((nPeople % nCapacity) > 0) nCourses++;

            Console.WriteLine(nCourses);

        }
    }
}
