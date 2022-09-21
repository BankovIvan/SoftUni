using System;
using System.Linq;

namespace _03_Largest_3_Numbers
{
    class Program { /* ONE LINE MAN! */ static void Main(string[] args) { Console.WriteLine(string.Join(" ", Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray().OrderByDescending(n => n).Take(3).ToArray() )); }}
}
