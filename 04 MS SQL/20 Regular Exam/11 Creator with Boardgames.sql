------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- Database Basics MS SQL Exam – 12 Feb 2023
--


------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- Section 4. Programmability (20 pts)
--


-------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- 11.	Creator with Boardgames
--

--USE Boardgames;


CREATE FUNCTION udf_CreatorWithBoardgames
(
	@name NVARCHAR(30)
) 
RETURNS
	INT
AS
	BEGIN

	DECLARE @TotalBoardGames INT = 0;

	SET @TotalBoardGames = 
		(
		SELECT
			COUNT(cb.BoardgameId)
		FROM
			Creators AS cr
			JOIN CreatorsBoardgames AS cb
			ON cr.Id = cb.CreatorId
		WHERE
			cr.FirstName = @name
		);

	RETURN @TotalBoardGames;

	END


-- SELECT dbo.udf_CreatorWithBoardgames('Bruno')
-- SELECT dbo.udf_CreatorWithBoardgames('KUR')
-- SELECT dbo.udf_CreatorWithBoardgames(NULL)






