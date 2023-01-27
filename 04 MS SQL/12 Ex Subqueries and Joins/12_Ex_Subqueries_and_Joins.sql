-------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- 12. Exercises: Subqueries and Joins
--


-------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- Part I – Queries for SoftUni Database
--
--USE SoftUni;


-------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- 1.	Employee Address
--
SELECT TOP(5) 
	e.EmployeeId
	, e.JobTitle
	, e.AddressID
	, a.AddressText 
FROM 
	Employees AS e
	LEFT JOIN Addresses AS a
	ON e.AddressID = a.AddressID
ORDER BY
	e.AddressID ASC;


-------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- 2.	Addresses with Towns
--
SELECT TOP(50) 
	e.FirstName
	, e.LastName
	, t.Name
	, a.AddressText 
FROM 
	Employees AS e
	LEFT JOIN Addresses AS a
	ON e.AddressID = a.AddressID
	LEFT JOIN Towns AS t
	ON a.TownID = t.TownID
ORDER BY
	e.FirstName ASC
	, e.LastName ASC;


-------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- 3.	Sales Employee
--
SELECT 
	e.EmployeeID
	, e.FirstName
	, e.LastName
	, d.Name AS DepartmentName
FROM 
	Employees AS e
	LEFT JOIN Departments AS d
	ON e.DepartmentID = d.DepartmentID
WHERE
	d.Name = 'Sales'
ORDER BY
	e.EmployeeID ASC;


-------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- 4.	Employee Departments
--
SELECT TOP(5) 
	e.EmployeeID
	, e.FirstName
	, e.Salary
	, d.Name AS DepartmentName
FROM 
	Employees AS e
	LEFT JOIN Departments AS d
	ON e.DepartmentID = d.DepartmentID
WHERE
	e.Salary > 15000
ORDER BY
	e.DepartmentID ASC;


-------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- 5.	Employees Without Project
--
SELECT TOP(3) 
	e.EmployeeID
	, e.FirstName
FROM 
	Employees AS e
	LEFT JOIN EmployeesProjects AS p
	ON e.EmployeeID = p.EmployeeID
WHERE
	p.EmployeeID IS NULL
ORDER BY
	e.EmployeeID ASC;



-------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- 6.	Employees Hired After
--
SELECT 
	e.FirstName
	, e.LastName
	, e.HireDate
	, d.Name AS DeptName
FROM 
	Employees AS e
	LEFT JOIN Departments AS d
	ON e.DepartmentID = d.DepartmentID
WHERE
	e.HireDate > '1999-01-01'
	AND d.Name IN ('Sales', 'Finance')
ORDER BY
	e.HireDate ASC;


-------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- 7.	Employees with Project
--
SELECT TOP(5) 
	e.EmployeeID
	, e.FirstName
	, p.Name AS ProjectName
FROM 
	Employees AS e
	JOIN EmployeesProjects AS ep
	ON e.EmployeeID = ep.EmployeeID
	JOIN Projects AS p
	ON ep.ProjectID = p.ProjectID
WHERE
	p.StartDate > '2002-08-13' 
	AND p.EndDate IS NULL
ORDER BY
	e.EmployeeID ASC;


-------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- 8.	Employee 24
--
SELECT
	e.EmployeeID
	, e.FirstName
	, IIF(p.StartDate >= '2005-01-01', NULL, p.Name) AS ProjectName
FROM 
	Employees AS e
	JOIN EmployeesProjects AS ep
	ON e.EmployeeID = ep.EmployeeID
	JOIN Projects AS p
	ON ep.ProjectID = p.ProjectID
WHERE
	e.EmployeeID = 24;


-------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- 9.	Employee Manager
--
SELECT
	e1.EmployeeID
	, e1.FirstName
	, e1.ManagerID
	, e2.FirstName AS ManagerName
FROM 
	Employees AS e1
	JOIN Employees AS e2
	ON e1.ManagerID = e2.EmployeeID
WHERE
	e2.EmployeeID IN (3, 7)
ORDER BY
	e1.EmployeeID ASC;


-------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- 10.	Employees Summary
--
SELECT TOP(50)
	e.EmployeeID
	, CONCAT_WS(' ', e.FirstName, e.LastName) AS EmployeeName
	, CONCAT_WS(' ', m.FirstName, m.LastName) AS ManagerName
	, d.Name AS DepartmentName
FROM 
	Employees AS e
	LEFT JOIN Employees AS m
	ON e.ManagerID = m.EmployeeID
	LEFT JOIN Departments AS d
	ON e.DepartmentID = d.DepartmentID
ORDER BY
	e.EmployeeID ASC;


-------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- 11.	Min Average Salary
--
SELECT TOP(1)
	AVG(e.Salary) AS MinAverageSalary
FROM 
	Employees AS e
GROUP BY
	e.DepartmentID
ORDER BY
	MinAverageSalary ASC;


-------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- Part II – Queries for Geography Database
--
-- USE Geography;

-------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- 12.	Highest Peaks in Bulgaria
--
SELECT
	c.CountryCode
	, m.MountainRange
	, p.PeakName
	, p.Elevation
FROM 
	Countries AS c
	LEFT JOIN MountainsCountries AS mc
	ON c.CountryCode = mc.CountryCode
	LEFT JOIN Mountains AS m
	ON mc.MountainId = m.Id
	LEFT JOIN Peaks AS p
	ON m.Id = p.MountainId
WHERE
	c.CountryName = 'Bulgaria'
	AND p.Elevation > 2835
ORDER BY
	p.Elevation DESC;



-------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- 13.	Count Mountain Ranges
--
SELECT
	c.CountryCode
	, COUNT(*) AS MountainRanges
FROM
	Countries AS c
	LEFT JOIN MountainsCountries AS mc
	ON c.CountryCode = mc.CountryCode
GROUP BY
	c.CountryCode
HAVING
	--c.CountryCode IN ('US', 'RU', 'BG');
	c.CountryCode IN (SELECT CountryCode FROM Countries WHERE CountryName IN ('United States', 'Russia', 'Bulgaria'));


-------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- 14.	Countries With or Without Rivers
--
SELECT TOP(5)
	c.CountryName
	, r.RiverName
FROM
	Countries AS c
	LEFT JOIN CountriesRivers AS cr
	ON c.CountryCode = cr.CountryCode
	LEFT JOIN Rivers AS r
	ON cr.RiverId = r.Id
	LEFT JOIN Continents AS cn
	ON c.ContinentCode = cn.ContinentCode
WHERE
	cn.ContinentName = 'Africa'
ORDER BY
	c.CountryName ASC;


-- OR--


SELECT TOP(5)
	 c.CountryName
	, MIN( r.RiverName)
FROM
	Countries AS c
	LEFT JOIN CountriesRivers AS cr
	ON c.CountryCode = cr.CountryCode
	LEFT JOIN Rivers AS r
	ON cr.RiverId = r.Id
	LEFT JOIN Continents AS cn
	ON c.ContinentCode = cn.ContinentCode
WHERE
	cn.ContinentName = 'Africa'
GROUP BY
	c.CountryName
ORDER BY
	c.CountryName ASC;


-------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- 15.	*Continents and Currencies
--
SELECT 
	sq2.ContinentCode
	, sq2.CurrencyCode
	, sq2.CurrencyUsage
FROM
	(
			SELECT 
				sq1.ContinentCode
				, sq1.CurrencyCode
				, sq1.CurrencyUsage
				, MAX(sq1.CurrencyUsage) OVER (PARTITION BY sq1.ContinentCode) AS MaxUsage
			FROM
				(
						SELECT
							ContinentCode
							, CurrencyCode
							, COUNT(CurrencyCode) AS CurrencyUsage
						FROM
							Countries
						GROUP BY
							ContinentCode
							, CurrencyCode
						HAVING
							COUNT(CurrencyCode) > 1
				) 
				AS sq1
	)
	AS sq2

WHERE
	sq2.CurrencyUsage = sq2.MaxUsage
ORDER BY
	sq2.ContinentCode ASC


-- OR --


SELECT 
	sq1.ContinentCode
	, sq1.CurrencyCode
	, sq1.CurrencyUsage
FROM
(
	SELECT
		ContinentCode
		, CurrencyCode
		, COUNT(CurrencyCode) AS CurrencyUsage
		, MAX(COUNT(CurrencyCode)) OVER (PARTITION BY ContinentCode) AS MaxUsage
	FROM
		Countries
	GROUP BY
		ContinentCode
		, CurrencyCode
	HAVING
		COUNT(CurrencyCode) > 1 
)
AS
	sq1
WHERE
	sq1.CurrencyUsage = sq1.MaxUsage
ORDER BY
	sq1.ContinentCode ASC;



-------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- 16.	Countries Without Any Mountains
--
SELECT 
	COUNT(*)
FROM
	Countries AS c
	LEFT JOIN MountainsCountries AS mc
	ON c.CountryCode = mc.CountryCode
WHERE
	mc.CountryCode IS NULL;


-------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- 17.	Countries Without Any Mountains
--
SELECT DISTINCT TOP(5)
	c.CountryName
	, MAX(p.Elevation) OVER (PARTITION BY c.CountryCode) AS HighestPeakElevation 
	, MAX(r.Length) OVER (PARTITION BY c.CountryCode) AS LongestRiverLength 
FROM
	Countries AS c
	LEFT JOIN MountainsCountries AS mc
	ON c.CountryCode = mc.CountryCode
	LEFT JOIN Peaks AS p
	ON mc.MountainId = p.MountainId
	LEFT JOIN CountriesRivers AS cr
	ON c.CountryCode = cr.CountryCode
	LEFT JOIN Rivers AS r
	ON cr.RiverId = r.Id
ORDER BY
	HighestPeakElevation DESC
	, LongestRiverLength DESC
	, c.CountryName ASC


-------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- 18.	Highest Peak Name and Elevation by Country
--

SELECT TOP(5)
	sq1.[Country]
	, ISNULL( sq1.[Highest Peak Name], '(no highest peak)')
	, ISNULL( sq1.[Highest Peak Elevation], 0)
	, ISNULL( sq1.[Mountain], '(no mountain)')
FROM
(
	SELECT
		c.CountryName AS [Country]
		, p.PeakName AS [Highest Peak Name]
		, p.Elevation AS [Elevation]
		, MAX(p.Elevation) OVER (PARTITION BY c.CountryCode) AS [Highest Peak Elevation]
		, m.MountainRange AS [Mountain]
	FROM
		Countries AS c
		LEFT JOIN MountainsCountries AS mc
		ON c.CountryCode = mc.CountryCode
		LEFT JOIN Peaks AS p
		ON mc.MountainId = p.MountainId
		LEFT JOIN Mountains AS m
		ON mc.MountainId = m.Id
) 
AS 
	sq1
WHERE
	sq1.[Elevation] = sq1.[Highest Peak Elevation]
	OR sq1.[Elevation] IS NULL
ORDER BY
	sq1.[Country] ASC
	, sq1.[Highest Peak Name] ASC



