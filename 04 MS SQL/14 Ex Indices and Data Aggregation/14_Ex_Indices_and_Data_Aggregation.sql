-------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- 14. Exercises: Indices and Data Aggregation
--


-------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- Part I – Queries for Gringotts Database
--
--USE Gringotts;


-------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- 1. Records' Count
--
SELECT 
	COUNT(*) AS Count
FROM 
	WizzardDeposits;


-------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- 2. Longest Magic Wand
--
SELECT 
	MAX(MagicWandSize) AS LongestMagicWand
FROM 
	WizzardDeposits;


-------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- 3. Longest Magic Wand Per Deposit Groups
--
SELECT 
	DepositGroup
	, MAX(MagicWandSize) AS LongestMagicWand
FROM 
	WizzardDeposits
GROUP BY
	DepositGroup;


-------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- 4. Smallest Deposit Group Per Magic Wand Size
--
SELECT TOP(2)
	DepositGroup
	--, AVG(MagicWandSize)
FROM 
	WizzardDeposits
GROUP BY
	DepositGroup
ORDER BY
	AVG(MagicWandSize) ASC;


-------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- 5. Deposits Sum
--
SELECT
	DepositGroup AS DepositGroup
	, SUM(DepositAmount) AS TotalSum
FROM 
	WizzardDeposits
GROUP BY
	DepositGroup;


-------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- 6. Deposits Sum for Ollivander Family
--
SELECT
	DepositGroup AS DepositGroup
	, SUM(DepositAmount) AS TotalSum
FROM 
	WizzardDeposits
WHERE
	[MagicWandCreator] = 'Ollivander Family'
GROUP BY
	DepositGroup;


-------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- 7. Deposits Filter
--
SELECT
	DepositGroup AS DepositGroup
	, SUM(DepositAmount) AS TotalSum
FROM 
	WizzardDeposits
WHERE
	[MagicWandCreator] = 'Ollivander Family'
GROUP BY
	DepositGroup
HAVING
	SUM(DepositAmount) < 150000
ORDER BY
	TotalSum DESC;


-------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- 8.  Deposit Charge
--
SELECT
	DepositGroup AS DepositGroup
	, MagicWandCreator AS MagicWandCreator
	, MIN(DepositCharge)
FROM 
	WizzardDeposits
GROUP BY
	DepositGroup
	, MagicWandCreator
ORDER BY
	MagicWandCreator ASC
	, DepositGroup ASC


-------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- 9. Age Groups
--
SELECT
	AgeGroup
	, COUNT(*)
FROM
	(


SELECT
	Id
	, Age
	, (CASE
		WHEN Age BETWEEN 0 AND 10 THEN '[0-10]'
		WHEN Age BETWEEN 11 AND 20 THEN '[11-20]'
		WHEN Age BETWEEN 21 AND 30 THEN '[21-30]'
		WHEN Age BETWEEN 31 AND 40 THEN '[31-40]'
		WHEN Age BETWEEN 41 AND 50 THEN '[41-50]'
		WHEN Age BETWEEN 51 AND 60 THEN '[51-60]'
		ELSE '[61+]'
		END) AS AgeGroup
FROM 
	WizzardDeposits

	) AS sq1

GROUP BY
	AgeGroup;


-------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- 10. First Letter
--
SELECT
	LEFT(FirstName, 1) AS FirstLetter
FROM
	WizzardDeposits
WHERE
	DepositGroup = 'Troll Chest'
GROUP BY
	LEFT(FirstName, 1);



-------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- 11. Average Interest 
--
SELECT 
	DepositGroup AS DepositGroup
	, IsDepositExpired AS IsDepositExpired
	, AVG(DepositInterest)
	--, DepositStartDate
	--, DepositExpirationDate
FROM
	WizzardDeposits
WHERE
	DepositStartDate > '1985-01-01'
GROUP BY
	DepositGroup
	, IsDepositExpired
ORDER BY
	DepositGroup DESC
	, IsDepositExpired ASC;
	

-------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- 12. *Rich Wizard, Poor Wizard
--

/*
SELECT 
	w1.FirstName AS [Host Wizard]
	, w1.DepositAmount AS [Host Wizard Deposit]
	, w2.FirstName AS [Guest Wizard]
	, w2.DepositAmount AS [Guest Wizard Deposit]
	, w2.DepositAmount - w1.DepositAmount AS [Difference]
FROM
	WizzardDeposits as w1
	JOIN WizzardDeposits as w2
	ON w1.Id = (w2.Id + 1)
*/

/*
SELECT 
	SUM(w2.DepositAmount - w1.DepositAmount) AS SumDifference
FROM
	WizzardDeposits as w1
	JOIN WizzardDeposits as w2
	ON w1.Id = (w2.Id + 1);
*/

SELECT
	SUM([Difference]) ROWS
FROM
	(

SELECT
	FirstName AS [Host Wizard]
	, DepositAmount AS [Host Wizard Deposit]
	, LEAD(FirstName) OVER (ORDER BY Id) AS [Guest Wizard]
	, LEAD(DepositAmount) OVER (ORDER BY Id) AS [Guest Wizard Deposit]
	, DepositAmount - LEAD(DepositAmount) OVER (ORDER BY Id) AS [Difference]
FROM
	WizzardDeposits 

	) AS sq1

-------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- Part II – Queries for SoftUni Database
--
--USE SoftUni;


-------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- 13. Departments Total Salaries
--
SELECT 
	DepartmentID
	, SUM(Salary) AS TotalSalary
FROM 
	Employees
GROUP BY
	DepartmentID
ORDER BY
	DepartmentID ASC;


-------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- 14. Employees Minimum Salaries
--
SELECT 
	DepartmentID
	, MIN(Salary) AS MinimumSalary
FROM 
	Employees
WHERE
	DepartmentID IN (2, 5, 7)
	AND HireDate > '2000-01-01'
GROUP BY
	DepartmentID
ORDER BY
	DepartmentID ASC;


-------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- 15. Employees Average Salaries
--

--DROP TABLE #Temp
--SELECT * FROM #Temp 

SELECT 
	*
INTO
	#Temp
FROM
	Employees
WHERE
	Salary > 30000;

DELETE 
FROM
	#Temp
WHERE
	ManagerID = 42

UPDATE
	#Temp
SET
	Salary = Salary + 5000
WHERE
	DepartmentID = 1 
	
SELECT
	DepartmentID AS DepartmentID
	, AVG(Salary) AS AverageSalary
FROM
	#Temp
GROUP BY
	DepartmentID


-------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- 16. Employees Maximum Salaries
--
SELECT 
	DepartmentID
	, MAX(Salary) AS MaxSalary
FROM 
	Employees
GROUP BY
	DepartmentID
HAVING
	MAX(Salary) NOT BETWEEN 30000 AND 70000;


-------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- 17. Employees Count Salaries
--
SELECT 
	COUNT(Salary)
FROM 
	Employees
WHERE
	ManagerID IS NULL;


-------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- 18. *3rd Highest Salary
--
SELECT DISTINCT
	DepartmentID
	, Salary
FROM 
	(

SELECT 
	DepartmentID
	, Salary
	, DENSE_RANK() OVER (PARTITION BY DepartmentID ORDER BY Salary DESC) AS ThirdHighestSalary
FROM 
	Employees

	) AS sq1
WHERE
	ThirdHighestSalary = 3;


-------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- 19. **Salary Challenge
--

SELECT TOP(10)
	FirstName
	, LastName
	, DepartmentID
	--, Salary
	--, AVGSalary
FROM
	(

SELECT
	FirstName
	, LastName
	, DepartmentID
	, Salary
	, AVG(Salary) OVER (PARTITION BY DepartmentID) AS AVGSalary
FROM 
	Employees

	) AS sq1

WHERE
	Salary > AVGSalary
ORDER BY
	DepartmentID;




SELECT TOP(10)
	FirstName
	, LastName
	, DepartmentID
	--, Salary
	--, AVGSalary
FROM
	Employees AS e
WHERE
	e.Salary >
	(

SELECT
	AVG(Salary)
FROM 
	Employees
WHERE
	DepartmentID = e.DepartmentID
GROUP BY 
	DepartmentID

	)

ORDER BY
	DepartmentID;

