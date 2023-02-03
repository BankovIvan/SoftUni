------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- 16. Exercises: Functions and Stored Procedures
--


-------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- Part III – Queries for Diablo Database
--
--USE Diablo;


-------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- 13.	*Scalar Function: Cash in User Games Odd Rows
--

CREATE OR ALTER FUNCTION ufn_CashInUsersGames 
(
	@GameName NVARCHAR(250)
)
RETURNS
	TABLE
AS
RETURN

 SELECT 
		SUM(sq1.Cash) AS [SumCash]
	FROM
	(

		SELECT 
			 g.Name AS [Name]
			 , u.Cash AS [Cash]
			 , ROW_NUMBER() OVER (ORDER BY u.Cash DESC) AS [Row]
		FROM
			Games AS g
			JOIN UsersGames as u
			ON g.Id = u.GameId
		WHERE
			g.Name = @GameName
		--ORDER BY
		--	u.Cash DESC

	) AS sq1
	WHERE
		sq1.Row % 2 <> 0




-- SELECT * FROM dbo.ufn_CashInUsersGames('Love in a mist')


