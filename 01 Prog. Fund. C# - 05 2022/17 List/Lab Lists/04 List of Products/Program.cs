using System;
using System.Collections.Generic;

namespace _04_List_of_Products
{
    class Program
    {
        static void Main(string[] args)
        {
            int i, nNumProducts;
            List<string> lstProducts = new List<string>();

            nNumProducts = int.Parse(Console.ReadLine());

            for (i = 0; i < nNumProducts; i++)
            {
                lstProducts.Add(Console.ReadLine());
            }

            lstProducts.Sort();

            for (i = 0; i < nNumProducts; i++)
            {
                Console.WriteLine((i + 1) + "." + lstProducts[i]);
            }

        }
    }
}
