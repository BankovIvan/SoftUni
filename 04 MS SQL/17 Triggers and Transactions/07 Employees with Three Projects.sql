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
-- 8.	Employees with Three Projects
--


CREATE OR ALTER PROCEDURE usp_AssignProject
(
	@emloyeeId INT
	, @projectID INT
)
AS
BEGIN

BEGIN TRANSACTION

	INSERT INTO		
		EmployeesProjects
	VALUES
		(@emloyeeId, @projectID)
	
	DECLARE @ProjectsCount INT = 
	(
		SELECT 
			COUNT(*)
		FROM
			EmployeesProjects
		WHERE
			EmployeeID = @emloyeeId
	);

	IF(@ProjectsCount > 3) 
	BEGIN;
		ROLLBACK;
		THROW 51000, 'The employee has too many projects!', 1;
	END;

COMMIT

END


-- usp_AssignProject 1, 1
-- usp_AssignProject 2, 4
-- usp_AssignProject 2, 24
-- usp_AssignProject 2, 38
-- usp_AssignProject 2, 113
-- SELECT * FROM EmployeesProjects







