-------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- 16. Exercises: Functions and Stored Procedures
--


-------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- Part I – Queries for SoftUni Database
--
--USE SoftUni;


-------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- 6.	Employees by Salary Level
--
CREATE OR ALTER PROCEDURE usp_EmployeesBySalaryLevel(@SalaryLevel NVARCHAR(10))
AS
BEGIN
	SELECT 
		FirstName
		, LastName
	FROM
		Employees
	WHERE
		@SalaryLevel = dbo.ufn_GetSalaryLevel(Salary)
		--'High' = dbo.ufn_GetSalaryLevel(Salary)
END;

-- EXECUTE usp_EmployeesBySalaryLevel 'High'
























