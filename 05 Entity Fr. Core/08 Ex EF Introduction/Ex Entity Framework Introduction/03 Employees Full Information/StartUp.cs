namespace SoftUni
{
    using SoftUni.Data;
    using SoftUni.Models;
    using System.Globalization;
    using System.Text;

    public class StartUp
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");

            using SoftUniContext context = new SoftUniContext();

            ///
            /// 3.	Employees Full Information
            ///
            /*
            string ret03 = GetEmployeesFullInformation(context);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(ret03);
            Console.ResetColor();
            */

            ///
            /// 4.	Employees with Salary Over 50 000
            ///
            /*
            string ret04 = GetEmployeesWithSalaryOver50000(context);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(ret04);
            Console.ResetColor();
            */

            ///
            /// 5.	Employees from Research and Development
            ///
            /*
            string ret05 = GetEmployeesFromResearchAndDevelopment(context);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(ret05);
            Console.ResetColor();
            */

            ///
            /// 6.	Adding a New Address and Updating Employee
            ///
            /*
            string ret06 = AddNewAddressToEmployee(context);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(ret06);
            Console.ResetColor();
            */

            ///
            /// 7.	Employees and Projects
            ///
            /*
            string ret07 = GetEmployeesInPeriod(context);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(ret07);
            Console.ResetColor();
            */

            ///
            /// 8.	Addresses by Town
            ///
            /*
            string ret08 = GetAddressesByTown(context);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(ret08);
            Console.ResetColor();
            */

            ///
            /// 9.	Employee 147
            ///
            /*
            string ret09 = GetEmployee147(context);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(ret09);
            Console.ResetColor();
            */

            /*
            ///
            /// 10.	Departments with More Than 5 Employees
            ///
            string ret10 = GetDepartmentsWithMoreThan5Employees(context);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(ret10);
            Console.ResetColor();
            */

            /*
            ///
            /// 11.	Find Latest 10 Projects
            ///
            string ret11 = GetLatestProjects(context);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(ret11);
            Console.ResetColor();
            */

            ///
            /// 12.	Increase Salaries
            ///
            /*
            string ret12 = IncreaseSalaries(context);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(ret12);
            Console.ResetColor();
            */

            ///
            /// 13.	Find Employees by First Name Starting with "Sa"
            ///
            /*
            string ret13 = GetEmployeesByFirstNameStartingWithSa(context);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(ret13);
            Console.ResetColor();
            */

            /*
            ///
            /// 14.	Delete Project by Id
            ///
            string ret14 = DeleteProjectById(context);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(ret14);
            Console.ResetColor();
            */


            ///
            /// 15.	Remove Town
            ///
            string ret15 = RemoveTown(context);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(ret15);
            Console.ResetColor();
            

        }

        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            StringBuilder ret = new StringBuilder();

            foreach (var employee in context.Employees.OrderBy(e => e.EmployeeId))
            {
                
                ret.AppendLine(String.Format("{0} {1} {2} {3} {4:F2}"
                                                , employee.FirstName
                                                , employee.LastName
                                                , employee.MiddleName
                                                , employee.JobTitle
                                                , employee.Salary
                                            ));
            }

            return ret.ToString().Trim();
        }

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            StringBuilder ret = new StringBuilder();

            foreach (var employee in context.Employees
                                                .Where(e => e.Salary > 50000)
                                                .OrderBy(e => e.FirstName))
            {

                ret.AppendLine(String.Format("{0} - {1:F2}"
                                                , employee.FirstName
                                                , employee.Salary
                                            ));
            }

            return ret.ToString().Trim();
        }

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            StringBuilder ret = new StringBuilder();

            /*
            int nDeparnenrIDToSearch = context.Departments
                                                .Where(d => d.Name == "Research and Development")
                                                .Select(d => d.DepartmentId)
                                                .First();

            var arrEmployeeData = context.Employees
                                            .Where(e => e.DepartmentId == nDeparnenrIDToSearch)
                                            .Select(d => new { d.FirstName, d.LastName, d.Salary })
                                            .OrderBy(d => d.Salary)
                                            .ThenByDescending(d => d.FirstName)
                                            .ToArray();
            */

            var arrEmployeeData = context.Employees
                                .Where(e => e.Department.Name == "Research and Development")
                                .Select(d => new { 
                                    d.FirstName
                                    , d.LastName
                                    , DepartmentName = d.Department.Name
                                    , d.Salary })
                                .OrderBy(d => d.Salary)
                                .ThenByDescending(d => d.FirstName)
                                .ToArray();

            foreach (var employee in arrEmployeeData)
            {

                ret.AppendLine(String.Format("{0} {1} from {2} - ${3:F2}"
                                                , employee.FirstName
                                                , employee.LastName
                                                , employee.DepartmentName
                                                , employee.Salary
                                            ));
            }

            return ret.ToString().Trim();
        }

        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            StringBuilder ret = new StringBuilder();

            Address address = new Address()
            {
                AddressText = "Vitoshka 15"
                , TownId = 4
            };

            Employee? newEmployee = context.Employees
                                .FirstOrDefault(e => e.LastName == "Nakov");

            newEmployee!.Address = address;

            context.SaveChanges();

            var arrEmployeeData = context.Employees
                                .OrderByDescending(e => e.AddressId)
                                .Take(10)
                                .Select(e => e.Address)
                                .ToArray();

            foreach (var employee in arrEmployeeData)
            {

                ret.AppendLine(String.Format("{0}"
                                                , employee!.AddressText
                                            ));
            }

            return ret.ToString().Trim();
        }

        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            StringBuilder ret = new StringBuilder();

            var arrEmployeeData = context.Employees
                                //.Where(e => e.EmployeesProjects
                                //    .Any(ep => ep.Project.StartDate.Year >= 2001
                                //                && ep.Project.StartDate.Year <= 2003))
                                .Take(10)
                                .Select(d => new {
                                    d.FirstName,
                                    d.LastName,
                                    ManagerFirstName = d.Manager!.FirstName,
                                    ManagerLastName = d.Manager.LastName,
                                    Projects = d.EmployeesProjects
                                                    .Where(ep => ep.Project.StartDate.Year >= 2001
                                                                    && ep.Project.StartDate.Year <= 2003)
                                                    .Select(ep => new
                                                    {
                                                        ProjectName = ep.Project.Name,
                                                        ProjectStartDate = ep.Project.StartDate.ToString("M/d/yyyy h:mm:ss tt",
                                                                                                    CultureInfo.InvariantCulture),
                                                        ProjectEndDate = ep.Project.EndDate.HasValue
                                                            ? ep.Project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt",
                                                                                                    CultureInfo.InvariantCulture)
                                                            : "not finished"

                                                    })
                                                    .ToArray()
                                })
                                .ToArray();

            foreach (var employee in arrEmployeeData)
            {

                ret.AppendLine(String.Format("{0} {1} - Manager: {2} {3}",
                                                employee.FirstName,
                                                employee.LastName,
                                                employee.ManagerFirstName,
                                                employee.ManagerLastName
                                            ));
                
                foreach(var project in employee.Projects) 
                {
                    ret.AppendLine(String.Format("--{0} - {1} - {2}",
                                                    project.ProjectName,
                                                    project.ProjectStartDate,
                                                    project.ProjectEndDate
                            ));
                }

            }

            return ret.ToString().Trim();
        }

        public static string GetAddressesByTown(SoftUniContext context)
        {
            StringBuilder ret = new StringBuilder();

            var arrAddresses = context.Addresses
                .OrderByDescending(a => a.Employees.Count)
                .ThenBy(a => a.Town.Name)
                .ThenBy(a => a.AddressText)
                .Select(a => new
                {
                    AddressText = a.AddressText,
                    TownName = a.Town.Name,
                    EmployeeCount = a.Employees.Count
                })
                .Take(10)
                .ToArray();

            foreach (var addr in arrAddresses)
            {

                ret.AppendLine(String.Format("{0}, {1} - {2} employees",
                                                addr.AddressText,
                                                addr.TownName,
                                                addr.EmployeeCount
                                            ));

            }

            return ret.ToString().Trim();
        }

        public static string GetEmployee147(SoftUniContext context)
        {
            StringBuilder ret = new StringBuilder();

            var employee = context.Employees
                .Where(e => e.EmployeeId == 147)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    Projects = e.EmployeesProjects
                        .OrderBy(p => p.Project.Name)
                        .Select(p => new 
                        {
                            p.Project.Name
                        })
                        .ToArray()
                })
                .First();

            ret.AppendLine(String.Format("{0} {1} - {2}",
                                            employee.FirstName,
                                            employee.LastName,
                                            employee.JobTitle
                                        ));

            foreach (var proj in employee.Projects)
            {
                ret.AppendLine(String.Format("{0}",
                                                proj.Name
                                            ));

            }

            return ret.ToString().Trim();
        }

        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            StringBuilder ret = new StringBuilder();

            var departments = context.Departments
                .Where(d => d.Employees.Count > 5)
                .OrderBy(d => d.Employees.Count > 5)
                .ThenBy(d => d.Name)
                .Select(d => new 
                {
                    DepartmentName = d.Name,
                    DepartmentManagerFirstName = d.Manager.FirstName,
                    DepartmentManagerLastName = d.Manager.LastName,
                    DeptEmployees = d.Employees
                        .OrderBy(e => e.FirstName)
                        .ThenBy(e => e.LastName)
                        .Select(e => new 
                        {
                            EmployeeFirstName = e.FirstName,
                            EmployeeLastName = e.LastName,
                            EmployeeJobTitle = e.JobTitle
                        })
                        .ToArray()
                })
                .ToArray();

            foreach(var dept in departments)
            {
                ret.AppendLine(String.Format("{0} – {1} {2}",
                                dept.DepartmentName,
                                dept.DepartmentManagerFirstName,
                                dept.DepartmentManagerLastName
                                ));

                foreach(var empl in dept.DeptEmployees)
                {
                    ret.AppendLine(String.Format("{0} {1} - {2}",
                        empl.EmployeeFirstName,
                        empl.EmployeeLastName,
                        empl.EmployeeJobTitle
                        ));
                }
            }

            return ret.ToString().Trim();
        }

        public static string GetLatestProjects(SoftUniContext context)
        {
            StringBuilder ret = new StringBuilder();

            var latestProjects = context.Projects
                .OrderByDescending(p => p.StartDate)
                .Take(10)
                .OrderBy(p => p.Name)
                .Select(p => new
                {
                    ProjectName = p.Name,
                    ProjectDescription = p.Description,
                    ProjectStartDate = p.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)
                })
                .ToArray();

            foreach (var proj in latestProjects)
            {
                ret.AppendLine(proj.ProjectName);
                ret.AppendLine(proj.ProjectDescription);
                ret.AppendLine(proj.ProjectStartDate);

            }

            return ret.ToString().Trim();
        }

        public static string IncreaseSalaries(SoftUniContext context)
        {
            StringBuilder ret = new StringBuilder();

            var luckyEmployees = context.Employees
                .Where(e => e.Department.Name == "Engineering"
                    || e.Department.Name == "Tool Design"
                    || e.Department.Name == "Marketing"
                    || e.Department.Name == "Information Services");

            foreach(var e in luckyEmployees)
            {
                e.Salary = e.Salary * (decimal)1.12;
            }

            context.SaveChanges();

            var updatedEmployees = luckyEmployees
                .Select(e => new 
                {
                    e.FirstName,
                    e.LastName,
                    e.Salary
                })
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToArray();

            foreach (var updatedEmployee in updatedEmployees)
            {
                ret.AppendLine(String.Format("{0} {1} (${2:F2})",
                    updatedEmployee.FirstName,
                    updatedEmployee.LastName,
                    updatedEmployee.Salary
                    ));

            }

            return ret.ToString().Trim();
        }

        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            StringBuilder ret = new StringBuilder();

            var saEmployees = context.Employees
                .Where(e => e.FirstName.StartsWith("Sa"))
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    e.Salary
                })
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToArray();

            foreach (var seEmployee in saEmployees)
            {
                ret.AppendLine(String.Format("{0} {1} - {2} - (${3:F2})",
                    seEmployee.FirstName,
                    seEmployee.LastName,
                    seEmployee.JobTitle,
                    seEmployee.Salary
                    ));

            }

            return ret.ToString().Trim();
        }

        public static string DeleteProjectById(SoftUniContext context)
        {
            StringBuilder ret = new StringBuilder();

            IQueryable<EmployeeProject> epToDelete = context.EmployeesProjects
                .Where(ep => ep.ProjectId == 2);

            context.EmployeesProjects.RemoveRange(epToDelete);

            Project projectToDelete = context.Projects.FirstOrDefault(p => p.ProjectId == 2)!;

            context.Projects.RemoveRange(projectToDelete);

            context.SaveChanges();

            string[] projectNames = context.Projects
                .Take(10)
                .Select(p => p.Name)
                .ToArray();

            ret.AppendLine(String.Join('\n', projectNames));

            return ret.ToString().Trim();
        }

        public static string RemoveTown(SoftUniContext context)
        {
            StringBuilder ret = new StringBuilder();

            var townToDelete = context.Towns.FirstOrDefault(t => t.Name == "Seattle")!;
            int nTownID = townToDelete!.TownId;

            var employeeToUpdate = context.Employees
                .Where(e => e.Address.TownId == nTownID);

            foreach( var employee in employeeToUpdate ) 
            {
                employee.AddressId = null;
            }

            var addressesToUpdate = context.Addresses
                .Where(a => a.TownId == nTownID);

            int nDeletedAddressesCount = addressesToUpdate.Count();

            context.Addresses.RemoveRange(addressesToUpdate);

            context.Towns.RemoveRange(townToDelete);


            context.SaveChanges();

            ret.AppendLine(String.Format("{0} addresses in Seattle were deleted", nDeletedAddressesCount));

            return ret.ToString().Trim();
        }

    }
}