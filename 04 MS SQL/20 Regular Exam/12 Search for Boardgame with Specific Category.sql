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
-- 12.	Search for Boardgame with Specific Category
--

--USE Boardgames;



CREATE PROCEDURE usp_SearchByCategory
(
	@category VARCHAR(50)
) 
AS
	BEGIN

	SELECT
		b.[Name] AS [Name]
		, b.YearPublished AS [YearPublished]
		, b.Rating AS [Rating]
		, c.[Name] AS [CategoryName]
		, p.[Name] AS [PublisherName]
		, CONCAT_WS(' ', pr.PlayersMin, 'people') AS [MinPlayers]
		, CONCAT_WS(' ', pr.PlayersMax, 'people') AS [MaxPlayers]
	FROM
		Categories AS c
		JOIN Boardgames AS b
		ON c.Id = b.CategoryId
		LEFT JOIN Publishers AS p
		ON p.Id = b.PublisherId
		LEFT JOIN PlayersRanges AS pr
		ON pr.Id = b.PlayersRangeId
	WHERE
		c.[Name] = @category
		--c.[Name] = 'Wargames'
	ORDER BY
		p.[Name] ASC
		, b.YearPublished DESC

	END


-- EXECUTE usp_SearchByCategory 'Wargames'
-- EXECUTE usp_SearchByCategory 'KUR'
-- EXECUTE usp_SearchByCategory NULL




