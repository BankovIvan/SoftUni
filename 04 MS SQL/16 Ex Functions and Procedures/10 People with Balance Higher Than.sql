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
-- 10.	People with Balance Higher Than
--


CREATE OR ALTER PROCEDURE usp_GetHoldersWithBalanceHigherThan
(
	@BalanceLimit DECIMAL(18,4)
)
AS
BEGIN

	SELECT
		FirstName
		, LastName
	FROM
		AccountHolders
	WHERE
		Id IN (

			SELECT 
				h.Id
				--, SUM(a.Balance) AS TotalBalance
			FROM 
				Accounts AS a
				JOIN AccountHolders AS h
				ON a.AccountHolderId = h.Id
			--WHERE
			--	h.IsDeleted = 0
			GROUP BY
				h.Id
			HAVING
				SUM(a.Balance) > @BalanceLimit

		)

	ORDER BY
		FirstName ASC
		, LastName ASC

END




