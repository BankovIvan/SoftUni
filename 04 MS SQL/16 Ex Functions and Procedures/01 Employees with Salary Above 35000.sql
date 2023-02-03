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
-- 1.	Employees with Salary Above 35000
--
CREATE OR ALTER PROCEDURE usp_GetEmployeesSalaryAbove35000 
AS
BEGIN
	SELECT 
		FirstName
		, LastName
	FROM
		Employees
	WHERE
		Salary > 35000
END;

-- EXECUTE usp_GetEmployeesSalaryAbove35000


