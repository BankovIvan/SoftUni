-------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- 10. Exercises: Built-in Functions
--
--USE SoftUni;


-------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- 1.	Find Names of All Employees by First Name
--
SELECT FirstName, LastName FROM Employees
WHERE FirstName Like 'Sa%';


-------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- 2.	Find Names of All Employees by Last Name 
--
SELECT FirstName, LastName FROM Employees
WHERE LastName Like '%ei%';


-------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- 3.	Find First Names of All Employees
--
SELECT FirstName FROM Employees
WHERE
	DepartmentID In (3, 10)
	AND DATEPART(yyyy, HireDate) BETWEEN 1995 AND 2005; 


-------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- 4.	Find All Employees Except Engineers
--
SELECT FirstName, LastName FROM Employees
WHERE JobTitle NOT Like '%engineer%';


-------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- 5.	Find Towns with Name Length
--
SELECT [Name] FROM Towns
WHERE LEN([Name]) IN (5, 6)
ORDER BY [Name] ASC;


-------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- 6.	Find Towns Starting With
--
SELECT TownID, [Name] FROM Towns
WHERE UPPER(SUBSTRING([Name], 1, 1)) IN ('M', 'K', 'B', 'E')
ORDER BY [Name] ASC;


-------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- 7.	Find Towns Not Starting With
--
SELECT TownID, [Name] FROM Towns
WHERE NOT UPPER(SUBSTRING([Name], 1, 1)) IN ('R', 'B', 'D')
ORDER BY [Name] ASC;


-------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- 8.	Create View Employees Hired After 2000 Year
--
CREATE VIEW [V_EmployeesHiredAfter2000] AS
SELECT FirstName, LastName FROM Employees
WHERE
	DATEPART(yyyy, HireDate) > 2000;


-------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- 9.	Length of Last Name
--
SELECT FirstName, LastName FROM Employees
WHERE
	LEN(LastName) = 5;


-------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- 10.	Rank Employees by Salary
--
SELECT 
	EmployeeID
	, FirstName
	, LastName
	, Salary
	, DENSE_RANK() OVER (PARTITION BY Salary ORDER BY EmployeeID ASC) AS [Rank]
FROM 
	Employees
WHERE
	Salary BETWEEN 10000 AND 50000
ORDER BY
	Salary DESC;


-------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- 11.	Find All Employees with Rank 2
--

SELECT 
	EmployeeID
	, FirstName
	, LastName
	, Salary
	, [Rank]
FROM

	(
		SELECT 
			EmployeeID
			, FirstName
			, LastName
			, Salary
			, DENSE_RANK() OVER (PARTITION BY Salary ORDER BY EmployeeID ASC) AS [Rank]
		FROM 
			Employees
		WHERE
			Salary BETWEEN 10000 AND 50000
	) AS SQ

WHERE
	[Rank] = 2
ORDER BY
	Salary DESC;


-------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- Part II – Queries for Geography Database
--
--USE GEOGRAPHY;

-------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- 12.	Countries Holding 'A' 3 or More Times
--
SELECT
	CountryName AS 'Country Name', IsoCode AS 'ISO Code'
FROM 
	Countries
--WHERE
--	LEN(CountryName) - LEN( REPLACE(UPPER(CountryName), 'A', '') ) >= 3
WHERE
	LEN(CountryName) - LEN( REPLACE(CountryName, 'A', '') COLLATE Latin1_General_CI_AS ) >= 3
ORDER BY
	IsoCode ASC;


-------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- 13.	 Mix of Peak and River Names
--
SELECT
	p.PeakName
	, r.RiverName 
	, LOWER(SUBSTRING(p.PeakName, 1, LEN(p.PeakName)-1) + r.RiverName) AS Mix
FROM Peaks AS p, Rivers AS r
WHERE RIGHT(p.PeakName, 1) = LEFT(r.RiverName, 1) COLLATE Latin1_General_CI_AS 
--WHERE LOWER(RIGHT(p.PeakName, 1)) = LOWER(LEFT(r.RiverName, 1)) 
ORDER BY
	Mix ASC;


-------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- Part III – Queries for Diablo Database
--
--USE Diablo;


-------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- 14.	Games from 2011 and 2012 Year
--
SELECT TOP(50) [Name], FORMAT([Start], 'yyyy-MM-dd') AS [Start] FROM Games
WHERE DATEPART(yyyy, [Start]) BETWEEN 2011 AND 2012
ORDER BY [Start] ASC, [Name] ASC


-------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- 15.	 User Email Providers
--
SELECT 
	Username
	, SUBSTRING(Email, CHARINDEX('@', Email) + 1, 1000) AS 'Email Provider' 
FROM 
	Users
ORDER BY 
	'Email Provider' ASC
	, Username ASC;


-------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- 16.	 Get Users with IP Address Like Pattern
--
SELECT 
	Username
	, IpAddress AS 'IP Address' 
FROM 
	Users
WHERE
	IpAddress LIKE '___.1%._%.___'
ORDER BY 
	Username ASC;


-------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- 17.	 Show All Games with Duration and Part of the Day
--
SELECT 
	[Name] AS 'Game'
	, CASE  
		WHEN DATEPART(hh, [Start]) BETWEEN 0 AND 11 THEN 'Morning'
		WHEN DATEPART(hh, [Start]) BETWEEN 12 AND 17 THEN 'Afternoon'
		ELSE 'Evening'
		END
		AS 'Part of the Day' 
	, 
	CASE  
		WHEN Duration IS NULL THEN 'Extra Long'
		WHEN Duration BETWEEN 0 AND 3 THEN 'Extra Short'
		WHEN Duration BETWEEN 4 AND 6 THEN 'Short'
		ELSE 'Long'
		END
	AS 'Duration' 
FROM 
	Games
ORDER BY 
	'Game' ASC
	, 'Duration' ASC
	, 'Part of the Day' ASC;


-------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- Part IV – Date Functions Queries
--
--USE Orders;


-------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- 18.	 Orders Table
--
SELECT 
	ProductName
	, OrderDate 
	, DATEADD(dd, 3, OrderDate) AS 'Pay Due'
	, DATEADD(MM, 1, OrderDate) AS 'Deliver Due'
FROM Orders


-------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- 19.	 People Table
--
CREATE TABLE People
(
	Id BIGINT IDENTITY(1,1) NOT NULL,
	[Name] VARCHAR(150) NOT NULL,
	BirthDate DATE NOT NULL
	CONSTRAINT PK_People PRIMARY KEY (Id),
);

INSERT 
	INTO People 
		([Name], BirthDate)
	VALUES 
		('Victor', '2000-12-07 00:00:00.000'),
		('Steven', '1992-09-10 00:00:00.000'),
		('Stephen', '1910-09-19 00:00:00.000'),
		('John', '2010-01-06 00:00:00.000');


--SELECT * FROM People;

SELECT 
	[Name]
	, DATEDIFF(yy, BirthDate, GETDATE()) AS 'Age in Years'
	, DATEDIFF(MM, BirthDate, GETDATE()) AS 'Age in Months'
	, DATEDIFF(dd, BirthDate, GETDATE()) AS 'Age in Days'
	, DATEDIFF(mi, BirthDate, GETDATE()) AS 'Age in Minutes'
FROM 
	People;










