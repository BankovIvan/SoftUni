------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- 16. Exercises: Functions and Stored Procedures
--


-------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- Part II – Queries for Bank Database
--
--USE Bank;


-------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- 12.	Calculating Interest
--


CREATE OR ALTER PROCEDURE usp_CalculateFutureValueForAccount 
(
	@AccoundId INT
	, @Interest FLOAT
)
AS
BEGIN

	SELECT
		a.Id AS [Account Id]
		, h.FirstName AS [First Name]
		, h.LastName AS [Last Name]
		, a.Balance AS [Current Balance]
		, dbo.ufn_CalculateFutureValue(a.Balance, @Interest, 5) AS [Balance in 5 years]
	FROM
		AccountHolders AS h
		JOIN Accounts AS a
		ON h.Id = a.AccountHolderId
	WHERE
		a.Id = @AccoundId

END

-- usp_CalculateFutureValueForAccount 1, 0.1


