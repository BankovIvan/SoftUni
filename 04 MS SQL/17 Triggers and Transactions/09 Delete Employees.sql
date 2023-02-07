------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- Exercises: Triggers and Transactions
--


-------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- Part III - Queries for SoftUni Database
--
--USE SoftUni;


-------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- 9.	Delete Employees
--


/*
CREATE TABLE Deleted_Employees
(
	EmployeeId INT NOT NULL IDENTITY(1, 1) -- IDENTITY is required by Judge
	, FirstName VARCHAR(50) NOT NULL
	, LastName VARCHAR(50) NOT NULL
	, MiddleName VARCHAR(50)
	, JobTitle VARCHAR(50) NOT NULL
	, DepartmentID INT NOT NULL
	, Salary MONEY NOT NULL
	, CONSTRAINT PK_Deleted_Employees PRIMARY KEY (EmployeeId)
)
*/


CREATE OR ALTER TRIGGER tr_OnDeleteEmployee
ON Employees FOR DELETE
AS
	INSERT INTO Deleted_Employees
	(
		FirstName
		, LastName
		, MiddleName
		, JobTitle
		, DepartmentID
		, Salary
	)


		SELECT
			FirstName
			, LastName
			, MiddleName
			, JobTitle
			, DepartmentID
			, Salary
		FROM 
			deleted

-- DELETE FROM EmployeesProjects WHERE EmployeeID = 1
-- UPDATE Employees SET ManagerID = NULL WHERE EmployeeID = 1
-- DELETE FROM Employees WHERE EmployeeID = 1

-- DELETE FROM EmployeesProjects WHERE EmployeeID = 2
-- UPDATE Employees SET ManagerID = NULL WHERE EmployeeID = 2
-- DELETE FROM Employees WHERE EmployeeID = 2

-- SELECT * FROM Deleted_Employees







