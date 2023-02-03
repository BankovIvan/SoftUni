------------------------------------------------------------------------------
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
-- 8.	Delete Employees and Departments
--


-- https://github.com/stefkavasileva/SoftUni-Software-Engineering/blob/master/DBFundamentals/Databases-Basics/07.Functions%20and%20Procedures/Functions%20and%20Procedures/08.%20Delete%20Employees%20and%20Departments.sql


CREATE PROCEDURE usp_DeleteEmployeesFromDepartment (@departmentId INT)
AS
BEGIN

	ALTER TABLE 
		Departments
	ALTER COLUMN 
		ManagerID INT NULL;

	DELETE FROM 
		EmployeesProjects
	WHERE
		EmployeeID IN (SELECT EmployeeID FROM Employees WHERE DepartmentID = @departmentId)

	UPDATE 
		Employees
	SET 
		ManagerID = NULL
	WHERE 
		ManagerID IN (SELECT EmployeeID FROM Employees WHERE DepartmentID = @departmentId)
	
	UPDATE 
		Departments
	SET 
		ManagerID = NULL
	WHERE 
		ManagerID IN (SELECT EmployeeID FROM Employees WHERE DepartmentID = @departmentId)

	DELETE FROM
		Employees
	WHERE
		DepartmentID = @departmentId
		--DepartmentID = 15

	DELETE FROM 
		Departments
	WHERE
		DepartmentID = @departmentId
		--DepartmentID = 15

	SELECT
		COUNT(*)
	FROM
		Employees
	WHERE
		DepartmentID = @departmentId

END;

-- EXECUTE usp_DeleteEmployeesFromDepartment 15




