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
-- 2.	Employees with Salary Above Number
--
CREATE OR ALTER PROCEDURE usp_GetEmployeesSalaryAboveNumber(@Number DECIMAL(18,4))
AS
BEGIN
	SELECT 
		FirstName
		, LastName
	FROM
		Employees
	WHERE
		Salary >= @Number
END;

-- EXECUTE usp_GetEmployeesSalaryAboveNumber 35000
























