using P03.Detail_Printer;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03.DetailPrinter
{
    public class DetailsPrinter
    {
        private IList<IDetailsPrinter> employees;

        public DetailsPrinter(IList<IDetailsPrinter> employees)
        {
            this.employees = employees;
        }

        public void PrintDetails()
        {
            /*
            foreach (Employee employee in this.employees)
            {
                if (employee is Manager)
                {
                    this.PrintManager((Manager)employee);
                }
                else
                {
                    this.PrintEmployee(employee);
                }
            }
            */

            foreach(var v in this.employees)
            {
                v.Print();
            }

        }

        private void PrintEmployee(Employee employee)
        {
            Console.WriteLine(employee.Name);
        }

        private void PrintManager(Manager manager)
        {
            Console.WriteLine(manager.Name);
            Console.WriteLine(string.Join(Environment.NewLine, manager.Documents));
        }
    }
}
