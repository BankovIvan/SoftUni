using P03.Detail_Printer;
using System;
using System.Collections.Generic;

namespace P03.DetailPrinter
{
    class Program
    {
        static void Main()
        {
            IDetailsPrinter detailsEmployee = new Employee("Goshko");

            ICollection<string> documents = new List<string>(new string[] { "DDS", "FDS", "BOD"});
            IDetailsPrinter detailsManager = new Manager("Bai Georgi", documents);

            DetailsPrinter printer = new DetailsPrinter(
                new List<IDetailsPrinter>(
                    new IDetailsPrinter[] { 
                        detailsEmployee, detailsManager }));

            printer.PrintDetails();
        }
    }
}
