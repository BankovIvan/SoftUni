using System;
using System.Collections.Generic;
using System.Numerics;

namespace _M01_Company_Roster
{

    class Employee
    {
        public string Name { get; set; }
        public double Salary { get; set; }
        public string Department { get; set; }

        public Employee(string Name, string Salary, string Department)
        {
            this.Name = Name;
            this.Salary = double.Parse(Salary);
            this.Department = Department;
        }
    }

    class Department
    {
        public string Name { get; set; }
        public List<Employee> Employees { get; set; }
        private double TotalSalary { get; set; }
        public double AverageSalary { get; set; }

        public Department(string Name)
        {
            this.Name = Name;
            Employees = new List<Employee>();
            TotalSalary = 0.0;
            AverageSalary = 0.0;
        }

        public void AddEmployee(Employee objEmployee)
        {
            Employees.Add(objEmployee);
            this.TotalSalary += objEmployee.Salary;
            this.AverageSalary = this.TotalSalary / this.Employees.Count;
        }

        public override string ToString()
        {
            string ret = "Highest Average Salary: " + this.Name;

            this.Employees.ForEach(x => ret = ret + string.Format("\n{0} {1:F2}", x.Name, x.Salary));

            return ret;
        }


    }

    class Program
    {
        static void Main(string[] args)
        {

            List<Department> lstDepartments = new List<Department>();
            Employee newEmployee;
            Department maxDepartment = new Department("None");
            string[] arrInput;
            int i, nRepeat, index;
            double dAverage;

            nRepeat = int.Parse(Console.ReadLine());
            for (i = 0; i < nRepeat; i++)
            {
                arrInput = Console.ReadLine().Split(' ');
                newEmployee = new Employee(arrInput[0], arrInput[1], arrInput[2]);

                if (!lstDepartments.Exists(x => x.Name == newEmployee.Department))
                {
                    lstDepartments.Add(new Department(newEmployee.Department));
                }

                lstDepartments.Find(x => x.Name == newEmployee.Department).AddEmployee(newEmployee);

            }

            //maxDepartment = lstDepartments.MaxBy()   .Max(x => x.AverageSalary);
            lstDepartments.ForEach(x => {
                if (x.AverageSalary > maxDepartment.AverageSalary)
                {
                    maxDepartment = x;
                }
            });

            maxDepartment.Employees.Sort((x, y) => y.Salary.CompareTo(x.Salary));

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(maxDepartment);
            Console.ResetColor();

        }
    }
}