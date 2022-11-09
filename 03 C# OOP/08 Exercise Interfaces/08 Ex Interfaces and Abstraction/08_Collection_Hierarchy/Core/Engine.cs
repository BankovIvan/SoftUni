namespace Collection.Core
{
    using Collection.Core.Interfaces;
    using Collection.Models;
    using Collection.Models.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Design;
    using System.Globalization;
    using System.Text;

    public class Engine : IEngine
    {
        public Engine()
        {

        }

        public void Run()
        {
            string[] arrInput  = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            int nRemove = int.Parse(Console.ReadLine());

            StringBuilder output1 = new StringBuilder();
            StringBuilder output2 = new StringBuilder();
            StringBuilder output3 = new StringBuilder();

            AddCollection addCollection = new AddCollection();
            AddRemoveCollection addRemoveCollection = new AddRemoveCollection();
            MyList myList = new MyList();

            foreach (var v in arrInput)
            {
                output1.Append(addCollection.Add(v));
                output1.Append(" ");
                output2.Append(addRemoveCollection.Add(v));
                output2.Append(" ");
                output3.Append(myList.Add(v));
                output3.Append(" ");
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(output1.ToString().Trim());
            Console.WriteLine(output2.ToString().Trim());
            Console.WriteLine(output3.ToString().Trim());
            Console.ResetColor();

            output2 = new StringBuilder();
            output3 = new StringBuilder();

            for (int i = 0; i < nRemove; i++)
            {
                output2.Append(addRemoveCollection.Remove());
                output2.Append(" ");
                output3.Append(myList.Remove());
                output3.Append(" ");
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(output2.ToString().Trim());
            Console.WriteLine(output3.ToString().Trim());
            Console.ResetColor();

        }
    }
}
