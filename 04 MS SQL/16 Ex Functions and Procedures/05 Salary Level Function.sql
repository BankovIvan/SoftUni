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
-- 5.	Salary Level Function
--
CREATE OR ALTER FUNCTION ufn_GetSalaryLevel
(
	@Salary DECIMAL(18,4)
)
RETURNS
	NVARCHAR(10)
AS
BEGIN
	DECLARE @SalaryLevel NVARCHAR(10) = NULL;
	SELECT @SalaryLevel =  
		CASE 
			WHEN @Salary < 30000 THEN 'Low'
			WHEN @Salary > 50000 THEN 'High'
			ELSE 'Average'
		END
	RETURN @SalaryLevel
END;

-- SELECT dbo.ufn_GetSalaryLevel(30000)
