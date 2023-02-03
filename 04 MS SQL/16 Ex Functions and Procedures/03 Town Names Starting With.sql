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
-- 3.	Town Names Starting With
--
CREATE OR ALTER PROCEDURE usp_GetTownsStartingWith(@StartingWith NVARCHAR(150))
AS
BEGIN
	SELECT 
		[Name]
	FROM
		Towns
	WHERE
		[Name] LIKE CONCAT(@StartingWith, '%')
END;

-- EXECUTE usp_GetTownsStartingWith b
























