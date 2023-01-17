------------------------------------------------------------------------
------------------------------------------------------------------------
-- MS SQL - януари 2023
-- 4. Exercise: CRUD


------------------------------------------------------------------------
------------------------------------------------------------------------
-- 1.	Examine the Databases


------------------------------------------------------------------------
------------------------------------------------------------------------
-- 2.	Find All the Information About Departments
-- USE SoftUni;
SELECT * FROM Departments;


------------------------------------------------------------------------
------------------------------------------------------------------------
-- 3.	Find all Department Names
-- USE SoftUni;
-- SELECT DISTINCT [Name] FROM Departments;
SELECT [Name] FROM Departments;


------------------------------------------------------------------------
------------------------------------------------------------------------
-- 4.	Find Salary of Each Employee
-- USE SoftUni;
SELECT FirstName, LastName, Salary FROM Employees;


------------------------------------------------------------------------
------------------------------------------------------------------------
-- 5.	Find Full Name of Each Employee
-- USE SoftUni;
SELECT FirstName, MiddleName, LastName FROM Employees;


------------------------------------------------------------------------
------------------------------------------------------------------------
-- 6.	Find Email Address of Each Employee
-- USE SoftUni;
SELECT FirstName + '.' + LastName + '@softuni.bg' AS 'Full Email Address' FROM Employees;


------------------------------------------------------------------------
------------------------------------------------------------------------
-- 7.	Find All Different Employees' Salaries
-- USE SoftUni;
SELECT DISTINCT Salary FROM Employees;


------------------------------------------------------------------------
------------------------------------------------------------------------
-- 8.	Find All Information About Employees
-- USE SoftUni;
SELECT * FROM Employees
	WHERE JobTitle = 'Sales Representative';


------------------------------------------------------------------------
------------------------------------------------------------------------
-- 9.	Find Names of All Employees by Salary in Range
-- USE SoftUni;
SELECT FirstName, LastName, JobTitle FROM Employees
	WHERE Salary >= 20000.0 AND Salary <= 30000.0;


------------------------------------------------------------------------
------------------------------------------------------------------------
-- 10.	Find Names of All Employees
-- USE SoftUni;
SELECT FirstName + ' ' + MiddleName + ' ' + LastName AS 'Full Name' FROM Employees
	WHERE Salary IN (25000.0, 14000.0, 12500.0, 23600.0);


------------------------------------------------------------------------
------------------------------------------------------------------------
-- 11.	Find All Employees Without a Manager
-- USE SoftUni;
SELECT FirstName, LastName FROM Employees
	WHERE ManagerID IS NULL;


------------------------------------------------------------------------
------------------------------------------------------------------------
-- 12.	Find All Employees with a Salary More Than 50000
-- USE SoftUni;
SELECT FirstName, LastName, Salary FROM Employees
	WHERE Salary > 50000.0
	ORDER BY Salary DESC;


------------------------------------------------------------------------
------------------------------------------------------------------------
-- 13.	Find 5 Best Paid Employees.
-- USE SoftUni;
SELECT TOP 5 FirstName, LastName FROM Employees
	ORDER BY Salary DESC;


------------------------------------------------------------------------
------------------------------------------------------------------------
-- 14.	Find All Employees Except Marketing
-- USE SoftUni;
SELECT FirstName, LastName FROM Employees
	WHERE DepartmentID <> 4;


------------------------------------------------------------------------
------------------------------------------------------------------------
-- 15.	Sort Employees Table
-- USE SoftUni;
SELECT * FROM Employees
	ORDER BY
		Salary DESC
		,FirstName ASC
		,LastName DESC
		, MiddleName ASC;


------------------------------------------------------------------------
------------------------------------------------------------------------
-- 16.	Create View Employees with Salaries
-- USE SoftUni;
CREATE VIEW V_EmployeesSalaries AS
SELECT FirstName, LastName, Salary FROM Employees;


------------------------------------------------------------------------
------------------------------------------------------------------------
-- 17.	Create View Employees with Job Titles
-- USE SoftUni;
CREATE VIEW V_EmployeeNameJobTitle AS
SELECT CONCAT(FirstName, ' ', MiddleName, ' ', LastName) AS 'Full Name', JobTitle AS 'Job Title' FROM Employees;
-- SELECT CONCAT_WS(' ', FirstName, MiddleName, LastName) AS 'Full Name', JobTitle AS 'Job Title' FROM Employees;

------------------------------------------------------------------------
------------------------------------------------------------------------
-- 18.	Distinct Job Titles
-- USE SoftUni;
SELECT DISTINCT JobTitle FROM Employees;


------------------------------------------------------------------------
------------------------------------------------------------------------
-- 19.	Find First 10 Started Projects
-- USE SoftUni;
SELECT TOP 10 * FROM Projects
	ORDER BY StartDate ASC, Name;


------------------------------------------------------------------------
------------------------------------------------------------------------
-- 20.	Last 7 Hired Employees
-- USE SoftUni;
SELECT TOP 7 FirstName, LastName, HireDate FROM Employees
	ORDER BY HireDate DESC;


------------------------------------------------------------------------
------------------------------------------------------------------------
-- 21.	Increase Salaries
-- USE SoftUni;
--SELECT Salary FROM Employees
UPDATE Employees
	SET Salary = Salary * 1.12
	WHERE DepartmentID IN 
		(
			SELECT DepartmentID FROM Departments 
				WHERE [Name] IN ('Engineering', 'Tool Design', 'Marketing', 'Information Services')
		);

SELECT Salary FROM Employees;


-- DROP DATABASE SoftUni;


------------------------------------------------------------------------
------------------------------------------------------------------------
-- 22.	All Mountain Peaks
-- USE Geography;

SELECT PeakName FROM Peaks
	ORDER BY PeakName ASC;


------------------------------------------------------------------------
------------------------------------------------------------------------
-- 23.	Biggest Countries by Population
-- USE Geography;

SELECT TOP 30 CountryName, [Population] FROM Countries
	WHERE ContinentCode = (SELECT ContinentCode FROM Continents WHERE ContinentName = 'Europe')
	ORDER BY [Population] DESC, CountryName ASC;


------------------------------------------------------------------------
------------------------------------------------------------------------
-- 24.	*Countries and Currency (Euro / Not Euro)
-- USE Geography;

SELECT CountryName, CountryCode, IIF(CurrencyCode = 'EUR', 'Euro', 'Not Euro') AS Currency FROM Countries
	ORDER BY CountryName ASC;


SELECT CountryName
	,CountryCode
	,(CASE CurrencyCode WHEN 'EUR' THEN 'Euro' ELSE 'Not Euro' END) AS Currency 
		FROM Countries
	ORDER BY CountryName ASC;


------------------------------------------------------------------------
------------------------------------------------------------------------
-- 25.	All Diablo Characters
-- USE Diablo;

SELECT [Name] FROM Characters
	ORDER BY [Name] ASC;




