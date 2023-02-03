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
-- 11.	Future Value Function
--

CREATE OR ALTER FUNCTION ufn_CalculateFutureValue 
(
	@I DECIMAL(18, 4)
	, @R FLOAT
	, @T INT
)
RETURNS
	DECIMAL(18, 4)
AS
BEGIN
	DECLARE @FV DECIMAL(18, 4) = NULL;

	SET @FV = @I * POWER((1.0 + @R), @T)

	RETURN @FV
END


-- SELECT dbo.ufn_CalculateFutureValue(1000, 0.1, 5)













