namespace MiniORMApp
{
    using MiniORMApp.DATA.Entities;
    using System.ComponentModel.DataAnnotations;
    
    public class StartUp
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            var context = new SoftUniDbContext(Config.ConnectionString);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Connected!");
            Console.ResetColor();

            context.Employees.Add(new Employee { 
                                        FirstName = "Gosho"
                                        , LastName = "Inserted"
                                        , DepartmentId = context.Departments.First().Id
                                        , IsEmployed = true
                                                });

            var employee = context.Employees.Last();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(employee.LastName + ", " + employee.FirstName);
            Console.ResetColor();

            employee.FirstName = "Modified";

            context.SaveChanges();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(employee.LastName + ", " + employee.FirstName);
            Console.ResetColor();

            context.Employees.Remove(employee);

            context.SaveChanges();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(context.Employees.Count);
            Console.ResetColor();

        }
    }
}