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
-- 4.	Employees from Town
--
CREATE OR ALTER PROCEDURE usp_GetEmployeesFromTown(@TownName NVARCHAR(150))
AS
BEGIN
	SELECT 
		FirstName
		, LastName
	FROM
		Towns AS t
		JOIN Addresses as a
		ON t.TownID = a.TownID
		JOIN Employees as e
		ON a.AddressID = e.AddressID
	WHERE
		t.[Name] = @TownName
END;

-- EXECUTE GetEmployeesFromTown Sofia
























