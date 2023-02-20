------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- Database Basics MS SQL Exam – 12 Feb 2023
--


------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- Section 3. Querying (40 pts)
--


-------------------------------------------------------------------------------
-------------------------------------------------------------------------------
-- 10.	Creators by Rating
--

--USE Boardgames;


SELECT
	cr.LastName AS [LastName]
	, CEILING(AVG(b.Rating)) AS [AverageRating]
	, p.[Name] AS [PublisherName]
FROM
	Creators AS cr
	JOIN CreatorsBoardgames AS cb
	ON cr.Id = cb.CreatorId
	JOIN Boardgames AS b
	ON b.Id = cb.BoardgameId
	JOIN Publishers AS p
	ON b.PublisherId = p.Id
WHERE
	p.[Name] = 'Stonemaier Games'
GROUP BY
	cr.Id
	, cr.LastName
	, p.[Name]
ORDER BY
	AVG(b.Rating) DESC

